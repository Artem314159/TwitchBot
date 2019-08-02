namespace TwitchBot
{
    partial class MainForm
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
            this.ChnlLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.RemovingComboBox = new System.Windows.Forms.ComboBox();
            this.RemoveChnlBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.BotNameCmbBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.entityCommand1 = new System.Data.Entity.Core.EntityClient.EntityCommand();
            this.MainMenuStrip = new System.Windows.Forms.MenuStrip();
            this.MenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RunCrocodileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConnectGrBox.SuspendLayout();
            this.EditChnlGrBox.SuspendLayout();
            this.MainMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.Location = new System.Drawing.Point(5, 19);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(100, 23);
            this.StartBtn.TabIndex = 0;
            this.StartBtn.Text = "Connect";
            this.StartBtn.UseVisualStyleBackColor = true;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click);
            // 
            // StopBtn
            // 
            this.StopBtn.Enabled = false;
            this.StopBtn.Location = new System.Drawing.Point(133, 19);
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
            this.LogBox.Location = new System.Drawing.Point(259, 44);
            this.LogBox.Name = "LogBox";
            this.LogBox.Size = new System.Drawing.Size(370, 250);
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
            this.AddChnlBtn.Click += new System.EventHandler(this.AddChnlBtn_Click);
            // 
            // ConnectGrBox
            // 
            this.ConnectGrBox.Controls.Add(this.StopBtn);
            this.ConnectGrBox.Controls.Add(this.StartBtn);
            this.ConnectGrBox.Location = new System.Drawing.Point(14, 89);
            this.ConnectGrBox.Name = "ConnectGrBox";
            this.ConnectGrBox.Size = new System.Drawing.Size(240, 55);
            this.ConnectGrBox.TabIndex = 5;
            this.ConnectGrBox.TabStop = false;
            this.ConnectGrBox.Text = "Set connection";
            // 
            // EditChnlGrBox
            // 
            this.EditChnlGrBox.Controls.Add(this.ChnlLanguageComboBox);
            this.EditChnlGrBox.Controls.Add(this.RemovingComboBox);
            this.EditChnlGrBox.Controls.Add(this.RemoveChnlBtn);
            this.EditChnlGrBox.Controls.Add(this.AddChnlBtn);
            this.EditChnlGrBox.Controls.Add(this.ChannelTxtBox);
            this.EditChnlGrBox.Enabled = false;
            this.EditChnlGrBox.Location = new System.Drawing.Point(14, 150);
            this.EditChnlGrBox.Name = "EditChnlGrBox";
            this.EditChnlGrBox.Size = new System.Drawing.Size(239, 144);
            this.EditChnlGrBox.TabIndex = 6;
            this.EditChnlGrBox.TabStop = false;
            this.EditChnlGrBox.Text = "Add/Remove";
            // 
            // ChnlLanguageComboBox
            // 
            this.ChnlLanguageComboBox.FormattingEnabled = true;
            this.ChnlLanguageComboBox.Location = new System.Drawing.Point(7, 109);
            this.ChnlLanguageComboBox.Name = "ChnlLanguageComboBox";
            this.ChnlLanguageComboBox.Size = new System.Drawing.Size(108, 21);
            this.ChnlLanguageComboBox.TabIndex = 8;
            // 
            // RemovingComboBox
            // 
            this.RemovingComboBox.FormattingEnabled = true;
            this.RemovingComboBox.Location = new System.Drawing.Point(125, 82);
            this.RemovingComboBox.Name = "RemovingComboBox";
            this.RemovingComboBox.Size = new System.Drawing.Size(108, 21);
            this.RemovingComboBox.TabIndex = 7;
            // 
            // RemoveChnlBtn
            // 
            this.RemoveChnlBtn.Location = new System.Drawing.Point(125, 39);
            this.RemoveChnlBtn.Name = "RemoveChnlBtn";
            this.RemoveChnlBtn.Size = new System.Drawing.Size(109, 23);
            this.RemoveChnlBtn.TabIndex = 6;
            this.RemoveChnlBtn.Text = "Remove channel:";
            this.RemoveChnlBtn.UseVisualStyleBackColor = true;
            this.RemoveChnlBtn.Click += new System.EventHandler(this.RemoveChnlBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(260, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Log:";
            // 
            // BotNameCmbBox
            // 
            this.BotNameCmbBox.FormattingEnabled = true;
            this.BotNameCmbBox.Location = new System.Drawing.Point(14, 44);
            this.BotNameCmbBox.Name = "BotNameCmbBox";
            this.BotNameCmbBox.Size = new System.Drawing.Size(240, 21);
            this.BotNameCmbBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Bot name:";
            // 
            // entityCommand1
            // 
            this.entityCommand1.CommandTimeout = 0;
            this.entityCommand1.CommandTree = null;
            this.entityCommand1.Connection = null;
            this.entityCommand1.EnablePlanCaching = true;
            this.entityCommand1.Transaction = null;
            // 
            // MainMenuStrip
            // 
            this.MainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuItem});
            this.MainMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MainMenuStrip.Name = "MainMenuStrip";
            this.MainMenuStrip.Size = new System.Drawing.Size(641, 24);
            this.MainMenuStrip.TabIndex = 10;
            this.MainMenuStrip.Text = "menuStrip1";
            // 
            // MenuItem
            // 
            this.MenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RunCrocodileItem});
            this.MenuItem.Name = "MenuItem";
            this.MenuItem.Size = new System.Drawing.Size(50, 20);
            this.MenuItem.Text = "Menu";
            // 
            // RunCrocodileItem
            // 
            this.RunCrocodileItem.Name = "RunCrocodileItem";
            this.RunCrocodileItem.Size = new System.Drawing.Size(180, 22);
            this.RunCrocodileItem.Text = "Run Crocodile";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 306);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BotNameCmbBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LogBox);
            this.Controls.Add(this.ConnectGrBox);
            this.Controls.Add(this.EditChnlGrBox);
            this.Controls.Add(this.MainMenuStrip);
            this.MainMenuStrip = this.MainMenuStrip;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ConnectGrBox.ResumeLayout(false);
            this.EditChnlGrBox.ResumeLayout(false);
            this.EditChnlGrBox.PerformLayout();
            this.MainMenuStrip.ResumeLayout(false);
            this.MainMenuStrip.PerformLayout();
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
        private System.Windows.Forms.ComboBox RemovingComboBox;
        private System.Windows.Forms.Button RemoveChnlBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ChnlLanguageComboBox;
        private System.Windows.Forms.ComboBox BotNameCmbBox;
        private System.Windows.Forms.Label label2;
        private System.Data.Entity.Core.EntityClient.EntityCommand entityCommand1;
        private System.Windows.Forms.MenuStrip MainMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem MenuItem;
        private System.Windows.Forms.ToolStripMenuItem RunCrocodileItem;
    }
}

