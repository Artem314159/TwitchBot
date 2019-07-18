using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;
using TwitchBot.Models;

namespace TwitchBot
{
    public partial class Form1 : Form
    {
        delegate void SafeCallDelegate(object sender, TwitchLib.Client.Events.OnLogArgs e);
        ChatBot Bot { get; set; } = new ChatBot();
        List<ChannelModel> Channels { get; set; } = new List<ChannelModel>();

        public Form1()
        {
            InitializeComponent();
            StopBtn.Enabled = false;
            ChnlLanguageComboBox.DataSource = new List<string> { "ru", "default" };
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            string botName = null, botToken = null;
            Channels = new List<ChannelModel>();

            XmlReaderSettings readerSettings = new XmlReaderSettings
                { IgnoreComments = true };
            using (XmlReader reader = XmlReader.Create(Application.StartupPath +
                @"\..\..\TwitchInfo.xml", readerSettings))
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(reader);
                XmlElement xRoot = xDoc.DocumentElement;

                foreach (XmlNode xnode in xRoot)
                {
                    switch (xnode.Name)
                    {
                        case "Bot":
                            botName = xnode.Attributes.GetNamedItem("name")?.Value;
                            botToken = xnode.Attributes.GetNamedItem("token")?.Value;
                            break;
                        case "Channels":
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                Channels.Add(new ChannelModel
                                {
                                    Name = childnode.InnerText,
                                    Language = childnode.Attributes.GetNamedItem("language")?.Value
                                });
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            Bot.OnLog += Bot_OnLog;

            Waiting(false);
            Bot.Connect(botName, botToken, Channels);
            Waiting(true);
            StartBtn.Enabled = false;
            StopBtn.Enabled = true;

            RemovingComboBox.DataSource = Bot.GetChannelList();
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
        }

        private void AddChnlBtn_Click(object sender, EventArgs e)
        {
            var channel = new ChannelModel { Name = ChannelTxtBox.Text, Language = (string)ChnlLanguageComboBox.SelectedItem };
            Bot.AddChannel(channel);
            RemovingComboBox.DataSource = Bot.GetChannelList();
        }

        private void RemoveChnlBtn_Click(object sender, EventArgs e)
        {
            var channel = (string)RemovingComboBox.SelectedItem;
            if (MessageBox.Show("Are you sure you want to remove channel " + channel, "Сообщение",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Bot.RemoveChannel(channel);
                RemovingComboBox.DataSource = Bot.GetChannelList();
            }
        }
    }
}
