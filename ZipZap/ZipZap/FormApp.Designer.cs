namespace ZipZap {
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
      this.SuspendLayout();
      // 
      // ButtonEncode
      // 
      this.ButtonEncode.Location = new System.Drawing.Point(62, 31);
      this.ButtonEncode.Name = "ButtonEncode";
      this.ButtonEncode.Size = new System.Drawing.Size(149, 23);
      this.ButtonEncode.TabIndex = 0;
      this.ButtonEncode.Text = "Encode to ZIPZAP";
      this.ButtonEncode.UseVisualStyleBackColor = true;
      this.ButtonEncode.Click += new System.EventHandler(this.ButtonOpenFile_Click);
      // 
      // ButtonDecode
      // 
      this.ButtonDecode.Location = new System.Drawing.Point(62, 60);
      this.ButtonDecode.Name = "ButtonDecode";
      this.ButtonDecode.Size = new System.Drawing.Size(149, 23);
      this.ButtonDecode.TabIndex = 1;
      this.ButtonDecode.Text = "Decode ZIPZAP";
      this.ButtonDecode.UseVisualStyleBackColor = true;
      this.ButtonDecode.Click += new System.EventHandler(this.ButtonDecode_Click);
      // 
      // FormApp
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(275, 107);
      this.Controls.Add(this.ButtonDecode);
      this.Controls.Add(this.ButtonEncode);
      this.Name = "FormApp";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "ZipZap!";
      this.Load += new System.EventHandler(this.FormApp_Load);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Button ButtonEncode;
    private System.Windows.Forms.Button ButtonDecode;
  }
}

