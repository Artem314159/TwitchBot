using System;
using System.Collections.Generic;
using System.Linq;
using TwitchBot.Models;
using TwitchBot.Services;
using TwitchLib.Client.Events;

namespace TwitchBot
{
    internal class ChatBot
    {
        private List<IDefaultClientService> _services = new List<IDefaultClientService>();
        public event EventHandler<OnLogArgs> OnLog;
        private string BotName;
        private string BotToken;

        internal void Connect(string botName, string botToken, List<ChannelModel> channels)
        {
            BotName = botName;
            BotToken = botToken;
            _services.Clear();

            foreach (var channel in channels)
            {
                AddChannel(channel);
            }
        }

        internal void AddChannel(ChannelModel channel)
        {
            IDefaultClientService service;
            switch (channel.Name)
            {
                case "Spac3crafter":
                    service = new Spac3crafterClientService(BotName, BotToken, channel.Name);
                    break;
                default:
                    if (channel.Language == "ru")
                        service = new RussianClientService(BotName, BotToken, channel.Name);
                    else
                        service = new DefaultClientService(BotName, BotToken, channel.Name);
                    break;
            }
            service.OnLog += Client_OnLog;
            _services.Add(service);
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

        internal List<string> GetChannelList()
        {
            return _services.Select(_ => _.ChannelName).ToList();
        }

        internal void RemoveChannel(string channel)
        {
            var service = _services.FirstOrDefault(_ => _.ChannelName == channel);
            if (service != null)
            {
                service.Disconnect();
                _services.Remove(service);
            }
        }
    }
}