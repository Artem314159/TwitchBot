using System;
using System.Collections.Generic;
using TwitchBot.Services;
using TwitchLib.Client.Events;

namespace TwitchBot
{
    internal class ChatBot
    {
        private List<IDefaultClientService> _services = new List<IDefaultClientService>();
        public event EventHandler<OnLogArgs> OnLog;

        internal void Connect(string botName, string botToken, List<string> channels)
        {
            foreach (var channel in channels)
            {
                IDefaultClientService service;
                switch (channel)
                {
                    case "Spac3crafter":
                        service = new Spac3crafterClientService(botName, botToken, channel);
                        break;
                    default:
                        service = new DefaultClientService(botName, botToken, channel);
                        break;
                }
                service.OnLog += Client_OnLog;
                _services.Add(service);
            }
        }

        public virtual void Client_OnLog(object sender, OnLogArgs e)
        {
            this.OnLog?.Invoke(sender, e);
        }
        internal void Disconnect()
        {
            foreach (var service in _services)
            {
                service.Disconnect();
            }
            _services.Clear();
        }
    }
}