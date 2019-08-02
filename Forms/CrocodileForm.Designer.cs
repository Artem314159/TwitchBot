namespace TwitchBot.Forms
{
    partial class CrocodileForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CrocodileRichTxtBox = new System.Windows.Forms.RichTextBox();
            this.CheckingWordTxtBox = new System.Windows.Forms.TextBox();
            this.ClearTxtBoxBtn = new System.Windows.Forms.Button();
            this.SetCheckWordBtn = new System.Windows.Forms.Button();
            this.StopBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CurrentWordTxtBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // CrocodileRichTxtBox
            // 
            this.CrocodileRichTxtBox.Location = new System.Drawing.Point(207, 32);
            this.CrocodileRichTxtBox.Name = "CrocodileRichTxtBox";
            this.CrocodileRichTxtBox.Size = new System.Drawing.Size(285, 251);
            this.CrocodileRichTxtBox.TabIndex = 0;
            this.CrocodileRichTxtBox.Text = "";
            // 
            // CheckingWordTxtBox
            // 
            this.CheckingWordTxtBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CheckingWordTxtBox.Location = new System.Drawing.Point(13, 102);
            this.CheckingWordTxtBox.Name = "CheckingWordTxtBox";
            this.CheckingWordTxtBox.Size = new System.Drawing.Size(188, 26);
            this.CheckingWordTxtBox.TabIndex = 1;
            // 
            // ClearTxtBoxBtn
            // 
            this.ClearTxtBoxBtn.Location = new System.Drawing.Point(12, 223);
            this.ClearTxtBoxBtn.Name = "ClearTxtBoxBtn";
            this.ClearTxtBoxBtn.Size = new System.Drawing.Size(188, 23);
            this.ClearTxtBoxBtn.TabIndex = 2;
            this.ClearTxtBoxBtn.Text = "Clear textbox";
            this.ClearTxtBoxBtn.UseVisualStyleBackColor = true;
            this.ClearTxtBoxBtn.Click += new System.EventHandler(this.ClearTxtBoxBtn_Click);
            // 
            // SetCheckWordBtn
            // 
            this.SetCheckWordBtn.Location = new System.Drawing.Point(12, 134);
            this.SetCheckWordBtn.Name = "SetCheckWordBtn";
            this.SetCheckWordBtn.Size = new System.Drawing.Size(188, 23);
            this.SetCheckWordBtn.TabIndex = 3;
            this.SetCheckWordBtn.Text = "Set new word";
            this.SetCheckWordBtn.UseVisualStyleBackColor = true;
            this.SetCheckWordBtn.Click += new System.EventHandler(this.SetCheckWordBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Location = new System.Drawing.Point(12, 194);
            this.StopBtn.Name = "StopBtn";
            this.StopBtn.Size = new System.Drawing.Size(189, 23);
            this.StopBtn.TabIndex = 4;
            this.StopBtn.Text = "Stop game";
            this.StopBtn.UseVisualStyleBackColor = true;
            this.StopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Current word:";
            // 
            // CurrentWordTxtBox
            // 
            this.CurrentWordTxtBox.Location = new System.Drawing.Point(12, 49);
            this.CurrentWordTxtBox.Name = "CurrentWordTxtBox";
            this.CurrentWordTxtBox.ReadOnly = true;
            this.CurrentWordTxtBox.Size = new System.Drawing.Size(188, 47);
            this.CurrentWordTxtBox.TabIndex = 6;
            this.CurrentWordTxtBox.Text = "";
            // 
            // CrocodileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 295);
            this.Controls.Add(this.CurrentWordTxtBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.StopBtn);
            this.Controls.Add(this.SetCheckWordBtn);
            this.Controls.Add(this.ClearTxtBoxBtn);
            this.Controls.Add(this.CheckingWordTxtBox);
            this.Controls.Add(this.CrocodileRichTxtBox);
            this.Name = "CrocodileForm";
            this.Text = "CrocodileForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox CrocodileRichTxtBox;
        private System.Windows.Forms.TextBox CheckingWordTxtBox;
        private System.Windows.Forms.Button ClearTxtBoxBtn;
        private System.Windows.Forms.Button SetCheckWordBtn;
        private System.Windows.Forms.Button StopBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox CurrentWordTxtBox;
    }
}