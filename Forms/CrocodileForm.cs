using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TwitchLib.Client.Events;

namespace TwitchBot.Forms
{
    public partial class CrocodileForm : Form
    {
        private readonly IDefaultClientService _service;
        delegate void SafeCallDelegate(OnMessageReceivedArgs e);
        private List<string> CheckingWordsToLower { get; set; }

        public CrocodileForm()
        {
            InitializeComponent();
        }

        public CrocodileForm(IDefaultClientService service) : this()
        {
            _service = service;
            _service.Client.Client.OnMessageReceived += Client_OnMessageReceived;
            this.Text = $"Crocodile - {service.ChannelName}";
        }

        public virtual void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            var lowerMessage = e.ChatMessage.Message.ToLower().Replace('ё', 'е').Split(' ', '-', ',', '?', '\\', '/', '.', ';', ':').ToList();
            if (CheckingWordsToLower != null && CheckingWordsToLower.All(_ => lowerMessage.Contains(_)))
                AddAnswer(e);
        }

        private void AddAnswer(OnMessageReceivedArgs e)
        {
            if (CrocodileRichTxtBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(AddAnswer);
                Invoke(d, new object[] { e });
            }
            else
            {
                CrocodileRichTxtBox.Text += $"{DateTime.Now}: ({e.ChatMessage.Channel}) {e.ChatMessage.Username}: \"{e.ChatMessage.Message}\".\n";
            }
        }

        private void ClearTxtBoxBtn_Click(object sender, EventArgs e)
        {
            CrocodileRichTxtBox.Text = string.Empty;
        }

        private void SetCheckWordBtn_Click(object sender, EventArgs e)
        {
            ChangeWord(CheckingWordTxtBox.Text);
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            ChangeWord(null);
        }

        private void ChangeWord(string text)
        {
            CheckingWordsToLower = text?.ToLower().Replace('ё', 'е').Split(' ', '-', ',').ToList();
            CurrentWordTxtBox.Text = text;
        }
    }
}
