using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Xml;

namespace TwitchBot
{
    public partial class Form1 : Form
    {
        delegate void SafeCallDelegate(object sender, TwitchLib.Client.Events.OnLogArgs e);
        ChatBot Bot { get; set; } = new ChatBot();
        List<string> Channels { get; set; }// = new List<string>();

        public Form1()
        {
            InitializeComponent();
            StopBtn.Enabled = false;
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            string botName = null, botToken = null;
            Channels = new List<string>();

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
                                Channels.Add(childnode.InnerText);
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
            //Worker.RunWorkerAsync($"{e.DateTime}: {e.Data}");
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

        /*private void StartBtn_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Application.StartupPath + @"\..\..\TwitchInfo.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            string botName = null, botToken = null;

            var channel = ChannelTxtBox.Text;
            StartBtn.Enabled = false;
            Bot.Connect(botName, botToken, channel);
            StopBtn.Enabled = true;
        }*/

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Waiting(false);
            Bot.Disconnect();
            Waiting(true);
            StartBtn.Enabled = true;
            StopBtn.Enabled = false;
        }
    }
}
