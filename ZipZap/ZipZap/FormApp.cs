﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ZipZap {
  public partial class FormApp: Form {
    private const string Ext = ".zipzap";
    private const string Filter = "ZipZap archives|*.zipzap";
    private readonly CancellationToken ctx = new CancellationToken();
    private string fileNameTemp = "";
      
    public FormApp() {
      InitializeComponent();
    }

    private async void ButtonOpenFile_Click(object sender, EventArgs e) {
      var dialog = new OpenFileDialog();
      var saveDialog = new SaveFileDialog() {
        Filter = Filter
      };
     
      if (dialog.ShowDialog() != DialogResult.OK || !File.Exists(dialog.FileName)) {
        return;
      }

      saveDialog.FileName = dialog.SafeFileName + Ext;
      fileNameTemp = dialog.SafeFileName + Ext;

      if (saveDialog.ShowDialog() != DialogResult.OK) {
        return;
      }
     
      using (var file = new FileStream(dialog.FileName, FileMode.Open)) {
        var buffer = new byte[file.Length];
        file.Read(buffer, 0, (int) file.Length);
        file.Close();

        var rle = new Rle(buffer);

        var progressIndicatorTotal = new Progress<int>(ProgressBarTotalUpdate);
        ProgressBarTotal.Minimum = 0;
        ProgressBarTotal.Maximum = buffer.Length;
        ProgressBarTotalUpdate(0);

        var limit = CheckBoxLimit.Checked ? Convert.ToInt32(EditSize.Value) : 0;

        if (buffer.Length < limit) {
          limit = 0;
          MessageBox.Show(@"Limit > file size. Limits disabled");
        }

        try {
          var bytes = await rle.Compress(limit, progressIndicatorTotal, this.ctx);

          using (var output = new FileStream(saveDialog.FileName, FileMode.Create)) {
            output.Write(bytes, 0, bytes.Length);
            output.Close();
          }
          
        } catch (OperationCanceledException) {
          // reserved

        } catch (Exception) {
          // reserved
        }
            
        MessageBox.Show(@"Done!");
      }          
    }

    private async void ButtonDecode_Click(object sender, EventArgs e) {
      var dialog = new OpenFileDialog() {
        Filter = Filter
      };

      var saveDialog = new SaveFileDialog();

      if (dialog.ShowDialog() != DialogResult.OK || !File.Exists(dialog.FileName)) {
        return;
      }

      if (dialog.SafeFileName != null) {
        saveDialog.FileName = dialog.SafeFileName.Substring(0, dialog.SafeFileName.Length - Ext.Length);
      }

      if (saveDialog.ShowDialog() != DialogResult.OK) {
        return;
      }

      using (var file = new FileStream(dialog.FileName, FileMode.Open)) {
        var buffer = new byte[file.Length];
        file.Read(buffer, 0, (int)file.Length);
        file.Close();

        var rle = new Rle(buffer);

        var progressIndicatorTotal = new Progress<int>(ProgressBarTotalUpdate);
        ProgressBarTotal.Minimum = 0;
        ProgressBarTotal.Maximum = buffer.Length;
        ProgressBarTotalUpdate(0);

        try {
          var bytes = await rle.Decompress(progressIndicatorTotal, this.ctx);

          using (var output = new FileStream(saveDialog.FileName, FileMode.Create)) {
            output.Write(bytes, 0, bytes.Length);
            output.Close();
          }
        }
        catch (OperationCanceledException) {
          // reserved

        }
        catch (Exception) {
          // reserved
        }
        finally {
          fileNameTemp = "";
        }
        
        MessageBox.Show(@"Done!");
      }
    }

    private void ProgressBarTotalUpdate(int value) {
      LabelTotal.Text = @"Total: " + value + @" / " + ProgressBarTotal.Maximum;
      ProgressBarTotal.Value = value;
    }

    private void FormApp_Load(object sender, EventArgs e) {
    }

    private void CheckBoxLimit_CheckStateChanged(object sender, EventArgs e) {
      EditSize.Enabled = CheckBoxLimit.Checked;
    }
  }
}
