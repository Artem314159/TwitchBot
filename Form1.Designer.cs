namespace TwitchBot
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.StartBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.ChannelTxtBox = new System.Windows.Forms.TextBox();
            this.LogBox = new System.Windows.Forms.RichTextBox();
            this.AddChnlBtn = new System.Windows.Forms.Button();
            this.ConnectGrBox = new System.Windows.Forms.GroupBox();
            this.EditChnlGrBox = new System.Windows.Forms.GroupBox();
            this.RemoveChnlBtn = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectGrBox.SuspendLayout();
            this.EditChnlGrBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(6, 36);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(100, 23);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Connect";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(134, 36);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(100, 23);
            this.StopBtn.TabIndex = 1;
            this.StopBtn.Text = "Disconnect";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // ChannelTxtBox
            // 
            this.ChannelTxtBox.Location = new System.Drawing.Point(6, 82);
            this.ChannelTxtBox.Name = "ChannelTxtBox";
            this.ChannelTxtBox.Size = new System.Drawing.Size(109, 20);
            this.ChannelTxtBox.TabIndex = 2;
            this.ChannelTxtBox.Text = "Spac3crafter";
            // 
            // LogBox
            // 
            this.LogBox.Location = new System.Drawing.Point(258, 33);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(370, 199);
            this.LogBox.TabIndex = 3;
            this.LogBox.Text = "";
            // 
            // AddChnlBtn
            // 
            this.AddChnlBtn.Location = new System.Drawing.Point(6, 39);
            this.AddChnlBtn.Name = "AddChnlBtn";
            this.AddChnlBtn.Size = new System.Drawing.Size(109, 23);
            this.AddChnlBtn.TabIndex = 4;
            this.AddChnlBtn.Text = "Add channel:";
            this.AddChnlBtn.UseVisualStyleBackColor = true;
            // 
            // ConnectGrBox
            // 
            this.ConnectGrBox.Controls.Add(this.StopBtn);
            this.ConnectGrBox.Controls.Add(this.StartBtn);
            this.ConnectGrBox.Location = new System.Drawing.Point(13, 13);
            this.ConnectGrBox.Name = "ConnectGrBox";
            this.ConnectGrBox.Size = new System.Drawing.Size(240, 84);
            this.ConnectGrBox.TabIndex = 5;
            this.ConnectGrBox.TabStop = false;
            this.ConnectGrBox.Text = "Set connection";
            // 
            // EditChnlGrBox
            // 
            this.EditChnlGrBox.Controls.Add(this.comboBox1);
            this.EditChnlGrBox.Controls.Add(this.RemoveChnlBtn);
            this.EditChnlGrBox.Controls.Add(this.AddChnlBtn);
            this.EditChnlGrBox.Controls.Add(this.ChannelTxtBox);
            this.EditChnlGrBox.Location = new System.Drawing.Point(13, 103);
            this.EditChnlGrBox.Name = "EditChnlGrBox";
            this.EditChnlGrBox.Size = new System.Drawing.Size(239, 129);
            this.EditChnlGrBox.TabIndex = 6;
            this.EditChnlGrBox.TabStop = false;
            this.EditChnlGrBox.Text = "Add/Remove";
            // 
            // RemoveChnlBtn
            // 
            this.RemoveChnlBtn.Location = new System.Drawing.Point(125, 39);
            this.RemoveChnlBtn.Name = "RemoveChnlBtn";
            this.RemoveChnlBtn.Size = new System.Drawing.Size(109, 23);
            this.RemoveChnlBtn.TabIndex = 6;
            this.RemoveChnlBtn.Text = "Remove channel:";
            this.RemoveChnlBtn.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(125, 82);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(108, 21);
            this.comboBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Log:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 244);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.ConnectGrBox);
            this.Controls.Add(this.EditChnlGrBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ConnectGrBox.ResumeLayout(false);
            this.EditChnlGrBox.ResumeLayout(false);
            this.EditChnlGrBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.TextBox ChannelTxtBox;
        private System.Windows.Forms.RichTextBox LogBox;
        private System.Windows.Forms.Button AddChnlBtn;
        private System.Windows.Forms.GroupBox ConnectGrBox;
        private System.Windows.Forms.GroupBox EditChnlGrBox;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button RemoveChnlBtn;
        private System.Windows.Forms.Label label1;
    }
}

