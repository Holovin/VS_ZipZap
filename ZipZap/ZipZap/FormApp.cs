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
using System.Windows.Forms;

namespace ZipZap {
  public partial class FormApp: Form {
    private const string Filter = "ZipZap archives|*.zipzap";
      
    public FormApp() {
      InitializeComponent();
    }

    private void ButtonOpenFile_Click(object sender, EventArgs e) {
      var dialog = new OpenFileDialog();
      var saveDialog = new SaveFileDialog() {
        Filter = Filter
      };
     
      if (dialog.ShowDialog() != DialogResult.OK || !File.Exists(dialog.FileName)) {
        return;
      }

      if (saveDialog.ShowDialog() != DialogResult.OK) {
        return;
      }
     
      using (var file = new FileStream(dialog.FileName, FileMode.Open)) {
        var buffer = new byte[file.Length];
        file.Read(buffer, 0, (int) file.Length);
        file.Close();

        var rle = new Rle(buffer);
        var bytes = rle.Compress();

        using (var output = new FileStream(saveDialog.FileName, FileMode.Create)) {
          output.Write(bytes, 0, bytes.Length);
          output.Close();  
        }
        
        MessageBox.Show("Done!");
      }          
    }

    private void ButtonDecode_Click(object sender, EventArgs e) {
      var dialog = new OpenFileDialog() {
        Filter = Filter
      };

      var saveDialog = new SaveFileDialog();

      if (dialog.ShowDialog() != DialogResult.OK || !File.Exists(dialog.FileName)) {
        return;
      }

      if (saveDialog.ShowDialog() != DialogResult.OK) {
        return;
      }

      using (var file = new FileStream(dialog.FileName, FileMode.Open)) {
        var buffer = new byte[file.Length];
        file.Read(buffer, 0, (int)file.Length);
        file.Close();

        var rle = new Rle(buffer);
        var bytes = rle.Decompress();

        using (var output = new FileStream(saveDialog.FileName, FileMode.Create)) {
          output.Write(bytes, 0, bytes.Length);
          output.Close();  
        }
        
        MessageBox.Show("Done!");
      }
    }

    private void FormApp_Load(object sender, EventArgs e) {
    }
  }
}
