using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZipZap {
  class Rle {    
    private readonly List<byte> buffer;

    public Rle(IEnumerable<byte> buffer) {
      this.buffer = buffer.ToList();
    }

    public Rle(List<byte> buffer) {
      this.buffer = buffer;
    }

    private bool CompareSeries(int index, int size) {
      if (index + (2 * size) > buffer.Count) {
        return false;
      }

      var limit = index + size;

      for (var i = index; i < limit; i++) {
        if (buffer[i] != buffer[i + size]) {
          return false;
        }
      }

      return true;
    }

    public byte[] Decode(IProgress<int> progressIndicatorTotal, CancellationToken ctx) {
      var output = new List<byte>();
      var index = 0;

      while (index < buffer.Count) {
        progressIndicatorTotal.Report(index);

        var repeatCount = BitConverter.ToInt32(buffer.GetRange(index, 4).ToArray(), 0);
        index += 4;

        var dataSize = BitConverter.ToInt32(buffer.GetRange(index, 4).ToArray(), 0);
        index += 4;

        do {
          output.AddRange(buffer.GetRange(index, dataSize));
          repeatCount--;
        } while (repeatCount >= 0);
        
        index += dataSize;
      }

      progressIndicatorTotal.Report(index);
      return output.ToArray();
    }

    public async Task<byte[]> Decompress(IProgress<int> progressIndicatorTotal, CancellationToken ctx) {
      return await Task.Run(() => Decode(progressIndicatorTotal, ctx), ctx);
    }

    public async Task<byte[]> Compress(int chunkLimit, IProgress<int> progressIndicatorTotal, CancellationToken ctx) {
      return await Task.Run(() => Encode(chunkLimit, progressIndicatorTotal, ctx), ctx);     
    }

    public byte[] Encode(int chunkLimit, IProgress<int> progressIndicatorTotal, CancellationToken ctx) {
      var output = new List<byte>();

      var index = 0;
      var uniqueStreakStart = -1;
      var uniqueStreakCount = 0;

      chunkLimit = chunkLimit == 0 ? buffer.Count : chunkLimit;

      do {
        progressIndicatorTotal.Report(index);

        var maxSeriesSize = 0;
        var maxStreak = 0;

        var localIndex = index;
        var localStreak = 0;
        var localSeriesSize = 8;

        // find [ABC] - [ABC] from INDEX to file end       
        var halfPart = (buffer.Count - index) / 2;

        while (localIndex < buffer.Count && localSeriesSize <= halfPart && localSeriesSize < chunkLimit) {
          //progressIndicatorIter.Report(localIndex);

          while (CompareSeries(localIndex, localSeriesSize)) {
            // if [ABC ABC] then check [ABC [ABC ABC]] 
            localIndex += localSeriesSize;
            localStreak++;
          }

          // if "save" length is better then old
          if (localStreak * localSeriesSize > maxStreak * maxSeriesSize) {
            maxSeriesSize = localSeriesSize;
            maxStreak = localStreak;
          }

          localIndex = index;
          localStreak = 0;
          localSeriesSize++;
        }

        // if not found
        if (maxStreak == 0 || maxSeriesSize == 0) {
          // if first time unique - save start index to save
          if (uniqueStreakCount == 0) {
            uniqueStreakStart = index;
          }

          // [AB] - [FD]
          uniqueStreakCount++;
          index++;
        } else {
          // reset and write unique if exist
          if (uniqueStreakCount != 0) {
            var uniqueStreakCountBytes = BitConverter.GetBytes(uniqueStreakCount);

            //// Header
            // repeat count (1 always!)
            output.AddRange(BitConverter.GetBytes(0));

            // bytes counter
            output.AddRange(uniqueStreakCountBytes);
            output.AddRange(buffer.GetRange(uniqueStreakStart, uniqueStreakCount));

            // reset
            uniqueStreakCount = 0;
            uniqueStreakStart = -1;
          }

          // save repeating part
          var maxSeriesSizeBytes = BitConverter.GetBytes(maxSeriesSize);

          //// Header
          // repeat count
          output.AddRange(BitConverter.GetBytes(maxStreak));

          // size
          output.AddRange(maxSeriesSizeBytes);
          output.AddRange(buffer.GetRange(index, maxSeriesSize));

          index += (maxStreak + 1) * maxSeriesSize;
        }
      } while (index < buffer.Count);

      if (uniqueStreakStart != -1 || uniqueStreakCount != 0) {
        var uniqueStreakCountBytes = BitConverter.GetBytes(uniqueStreakCount);

        output.AddRange(BitConverter.GetBytes(0));
        output.AddRange(uniqueStreakCountBytes);
        output.AddRange(buffer.GetRange(uniqueStreakStart, uniqueStreakCount));
      }

      progressIndicatorTotal.Report(index);
      return output.ToArray();
    }
  }
}
