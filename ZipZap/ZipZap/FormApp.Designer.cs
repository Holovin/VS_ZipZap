﻿namespace ZipZap {
  partial class FormApp {
    /// <summary>
    /// Требуется переменная конструктора.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Освободить все используемые ресурсы.
    /// </summary>
    /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Код, автоматически созданный конструктором форм Windows

    /// <summary>
    /// Обязательный метод для поддержки конструктора - не изменяйте
    /// содержимое данного метода при помощи редактора кода.
    /// </summary>
    private void InitializeComponent() {
      this.ButtonEncode = new System.Windows.Forms.Button();
      this.ButtonDecode = new System.Windows.Forms.Button();
      this.ProgressBarTotal = new System.Windows.Forms.ProgressBar();
      this.LabelTotal = new System.Windows.Forms.Label();
      this.LabelPromo = new System.Windows.Forms.Label();
      this.CheckBoxLimit = new System.Windows.Forms.CheckBox();
      this.EditSize = new System.Windows.Forms.NumericUpDown();
      ((System.ComponentModel.ISupportInitialize)(this.EditSize)).BeginInit();
      this.SuspendLayout();
      // 
      // ButtonEncode
      // 
      this.ButtonEncode.Location = new System.Drawing.Point(12, 3);
      this.ButtonEncode.Name = "ButtonEncode";
      this.ButtonEncode.Size = new System.Drawing.Size(251, 23);
      this.ButtonEncode.TabIndex = 0;
      this.ButtonEncode.Text = "Encode to ZIPZAP";
      this.ButtonEncode.UseVisualStyleBackColor = true;
      this.ButtonEncode.Click += new System.EventHandler(this.ButtonOpenFile_Click);
      // 
      // ButtonDecode
      // 
      this.ButtonDecode.Location = new System.Drawing.Point(12, 32);
      this.ButtonDecode.Name = "ButtonDecode";
      this.ButtonDecode.Size = new System.Drawing.Size(251, 23);
      this.ButtonDecode.TabIndex = 1;
      this.ButtonDecode.Text = "Decode ZIPZAP";
      this.ButtonDecode.UseVisualStyleBackColor = true;
      this.ButtonDecode.Click += new System.EventHandler(this.ButtonDecode_Click);
      // 
      // ProgressBarTotal
      // 
      this.ProgressBarTotal.Location = new System.Drawing.Point(12, 72);
      this.ProgressBarTotal.Name = "ProgressBarTotal";
      this.ProgressBarTotal.Size = new System.Drawing.Size(251, 23);
      this.ProgressBarTotal.TabIndex = 3;
      // 
      // LabelTotal
      // 
      this.LabelTotal.Location = new System.Drawing.Point(269, 72);
      this.LabelTotal.Name = "LabelTotal";
      this.LabelTotal.Size = new System.Drawing.Size(151, 23);
      this.LabelTotal.TabIndex = 4;
      this.LabelTotal.Text = "0/0   ";
      this.LabelTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
      // 
      // LabelPromo
      // 
      this.LabelPromo.ForeColor = System.Drawing.SystemColors.InactiveCaption;
      this.LabelPromo.Location = new System.Drawing.Point(269, 3);
      this.LabelPromo.Name = "LabelPromo";
      this.LabelPromo.Size = new System.Drawing.Size(163, 52);
      this.LabelPromo.TabIndex = 6;
      this.LabelPromo.Text = "by Alex Holovin (c) 2015\r\nThis is free Software, published under the BSD-3-Clause" +
    " license.";
      // 
      // CheckBoxLimit
      // 
      this.CheckBoxLimit.AutoSize = true;
      this.CheckBoxLimit.Checked = true;
      this.CheckBoxLimit.CheckState = System.Windows.Forms.CheckState.Checked;
      this.CheckBoxLimit.Location = new System.Drawing.Point(12, 101);
      this.CheckBoxLimit.Name = "CheckBoxLimit";
      this.CheckBoxLimit.Size = new System.Drawing.Size(98, 17);
      this.CheckBoxLimit.TabIndex = 7;
      this.CheckBoxLimit.Text = "Chunk size limit";
      this.CheckBoxLimit.UseVisualStyleBackColor = true;
      this.CheckBoxLimit.CheckStateChanged += new System.EventHandler(this.CheckBoxLimit_CheckStateChanged);
      // 
      // EditSize
      // 
      this.EditSize.Location = new System.Drawing.Point(143, 98);
      this.EditSize.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
      this.EditSize.Minimum = new decimal(new int[] {
            255,
            0,
            0,
            0});
      this.EditSize.Name = "EditSize";
      this.EditSize.Size = new System.Drawing.Size(120, 20);
      this.EditSize.TabIndex = 8;
      this.EditSize.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
      // 
      // FormApp
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(432, 123);
      this.Controls.Add(this.EditSize);
      this.Controls.Add(this.CheckBoxLimit);
      this.Controls.Add(this.LabelPromo);
      this.Controls.Add(this.LabelTotal);
      this.Controls.Add(this.ProgressBarTotal);
      this.Controls.Add(this.ButtonDecode);
      this.Controls.Add(this.ButtonEncode);
      this.MaximizeBox = false;
      this.MinimumSize = new System.Drawing.Size(440, 132);
      this.Name = "FormApp";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ZipZap!";
      this.Load += new System.EventHandler(this.FormApp_Load);
      ((System.ComponentModel.ISupportInitialize)(this.EditSize)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button ButtonEncode;
    private System.Windows.Forms.Button ButtonDecode;
    private System.Windows.Forms.ProgressBar ProgressBarTotal;
    private System.Windows.Forms.Label LabelTotal;
    private System.Windows.Forms.Label LabelPromo;
    private System.Windows.Forms.CheckBox CheckBoxLimit;
    private System.Windows.Forms.NumericUpDown EditSize;
  }
}

