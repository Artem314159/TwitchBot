using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Linq;
using System.Linq;
using TwitchBot.Data;
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
        private BotContext db;

        public ChatBot(BotContext db)
        {
            this.db = db;
        }

        internal void Connect(BotCredential credential, List<ChannelModel> channels)
        {
            BotName = credential.Name;
            BotToken = credential.Token;
            _services.Clear();

            foreach (var channel in channels)
            {
                AddChannel(channel);
            }
        }

        internal void AddChannel(ChannelModel channel)
        {
            IDefaultClientService service;
            switch (channel.Name.ToLower())
            {
                case "spac3crafter":
                    service = new Spac3crafterClientService(db, BotName, BotToken, channel.Name);
                    break;
                case "vika_karter":
                    service = new Vika_KarterClientService(db, BotName, BotToken, channel.Name);
                    break;
                default:
                    if (channel.Language == Language.Ru)
                        service = new RussianClientService(db, BotName, BotToken, channel.Name);
                    else
                        service = new DefaultClientService(db, BotName, BotToken, channel.Name);
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

        public IDefaultClientService GetServiceByChannelName(string channelName)
        {
            return _services.FirstOrDefault(_ => _.ChannelName == channelName);
        }
    }
}