using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Xml;

namespace TwitchBot
{
    public partial class Form1 : Form
    {
        ChatBot Bot { get; set; } = new ChatBot();
        List<string> Channels { get; set; }// = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(Application.StartupPath + @"\..\..\TwitchInfo.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            string botName = null, botToken = null;

            Channels = new List<string>();
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

            this.Enabled = false;
            Bot.Connect(botName, botToken, Channels);
            this.Enabled = true;
        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            Bot.Disconnect();
        }
    }
}
