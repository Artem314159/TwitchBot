using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data.Entity;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using TwitchBot.Data;
using TwitchBot.Forms;
using TwitchBot.Models;

namespace TwitchBot
{
    public partial class MainForm : Form
    {
        delegate void SafeCallDelegate(object sender, TwitchLib.Client.Events.OnLogArgs e);
        ChatBot Bot { get; set; }// = new ChatBot();
        List<ChannelModel> Channels { get; set; } = new List<ChannelModel>();

        private readonly string ConnectionString;
        private BotContext db;

        public MainForm()
        {
            InitializeComponent();
            ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DbConnect();
            ChnlLanguageComboBox.DataSource = Enum.GetNames(typeof(Language));
            BotNameCmbBox.DataSource = db.BotCredentials.Select(_ => _.Name).ToList();
        }

        private void DbConnect()
        {
            SqlConnection connection = new SqlConnection(ConnectionString);
            connection.Open();
            db = new BotContext(connection);
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            Bot = new ChatBot(db);
            BotCredential credential = db.BotCredentials.FirstOrDefault(_ => _.Name == (string)BotNameCmbBox.SelectedItem);
            Channels = db.Channels.Select(_ => new ChannelModel
            {
                Name = _.Name,
                Language = _.ChannelLanguage
            }).ToList();

            Bot.OnLog += Bot_OnLog;

            Waiting(false);
            Bot.Connect(credential, Channels);
            Waiting(true);
            StartBtn.Enabled = false;
            StopBtn.Enabled = true;

            ChangeChannelList(Bot.GetChannelList());
        }

        private void Bot_OnLog(object sender, TwitchLib.Client.Events.OnLogArgs e)
        {
            if (LogBox.InvokeRequired)
            {
                var d = new SafeCallDelegate(Bot_OnLog);
                Invoke(d, new object[] { sender, e });
            }
            else
            {
                LogBox.Text += $"{e.DateTime}: {e.Data}\n";
            }
        }

        private void Waiting(bool isFinished)
        {
            ConnectGrBox.Enabled = isFinished;
            EditChnlGrBox.Enabled = isFinished;
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LogBox.Text += e.Result;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Waiting(false);
            Bot.Disconnect();
            Waiting(true);
            StartBtn.Enabled = true;
            StopBtn.Enabled = false;
            Bot.OnLog -= Bot_OnLog;
        }

        private void AddChnlBtn_Click(object sender, EventArgs e)
        {
            Enum.TryParse((string)ChnlLanguageComboBox.SelectedItem, out Language language);
            var channel = new ChannelModel { Name = ChannelTxtBox.Text, Language = language};
            Bot.RemoveChannel(channel.Name);
            Bot.AddChannel(channel);
            ChangeChannelList(Bot.GetChannelList());
        }

        private void RemoveChnlBtn_Click(object sender, EventArgs e)
        {
            var channel = (string)RemovingComboBox.SelectedItem;
            if (MessageBox.Show("Are you sure you want to remove channel " + channel, "Сообщение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Bot.RemoveChannel(channel);
                ChangeChannelList(Bot.GetChannelList());
            }
        }

        private void ChangeChannelList(List<string> channels)
        {
            RemovingComboBox.DataSource = channels;
            RunCrocodileItem.DropDownItems.Clear();
            foreach (var channelName in channels)
            {
                var dropDownItem = new ToolStripMenuItem
                {
                    Name = channelName + "",
                    Text = $"Start on \"{channelName}\""
                };
                dropDownItem.Click += (s, e) => RunCrocodile(channelName);
                RunCrocodileItem.DropDownItems.Add(dropDownItem);
            }
        }

        private void RunCrocodile(string channelName)
        {
            var crocodileForm = new CrocodileForm(Bot.GetServiceByChannelName(channelName));
            crocodileForm.Show();
        }
    }
}
