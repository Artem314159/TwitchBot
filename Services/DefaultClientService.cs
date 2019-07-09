using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;

namespace TwitchBot
{
    public class DefaultClientService : IDefaultClientService
    {
        protected ConnectionCredentials Credentials;
        protected CustomClientModel Client;

        public event EventHandler<OnLogArgs> OnLog;
        public readonly string BotName;
        public readonly string BotToken;
        public readonly string ChannelName;

        public DefaultClientService(string botName, string botToken, string channelName)
        {
            BotName = botName;
            BotToken = botToken;
            ChannelName = channelName;
            Credentials = new ConnectionCredentials(botName, botToken);
            var client = new TwitchClient();
            client.Initialize(Credentials, channelName);

            Client = new CustomClientModel(client);

            //is posible because model contain property "client"
            client.OnConnected += (s, ev) => Client_OnConnected(Client, ev);
            client.OnMessageReceived += (s, ev) => Client_OnMessageReceived(Client, ev);
            client.OnJoinedChannel += (s, ev) => Client_OnJoinedChannel(Client, ev);
            client.OnUserStateChanged += (s, ev) => Client_OnUserStateChanged(Client, ev);
            client.OnMessageThrottled += (s, ev) => Client_OnMessageThrottled(Client, ev);
            //client.OnLog += Client_OnLog;

            client.Connect();
        }

        public virtual void Client_OnMessageThrottled(object sender, OnMessageThrottledEventArgs e)
        {
            throw new NotImplementedException();
        }

        public virtual void Client_OnLog(object sender, OnLogArgs e)
        {
            this.OnLog?.Invoke(sender, e);
        }

        public virtual void Client_OnUserStateChanged(object sender, OnUserStateChangedArgs e)
        {
            Client.UserType = e.UserState.UserType;
            Client.IsSub = e.UserState.IsSubscriber;
            Client.HasVIP = e.UserState.Badges.Any(_ => _.Key == "vip");
        }

        public virtual void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            //if (model.Client.JoinedChannels.Any(_ => _.Channel == e.Channel))
            //    model.Client.SendMessage(e.Channel, "Bot joined.");
            Client_OnLog(sender, new OnLogArgs
            {
                BotUsername = BotName,
                Data = $"Bot joined to {ChannelName}.",
                DateTime = DateTime.Now
            });
        }

        public virtual void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            if (Client.Client.JoinedChannels.Count == 0)
            {
                Client.Client.JoinChannel(ChannelName);
            }
                Client.ChannelName = Client.Client.JoinedChannels[0].Channel;
                //if (model.Client.JoinedChannels.Any(_ => _.Channel == e.AutoJoinChannel))
                //    model.Client.SendMessage(e.AutoJoinChannel, "Bot connected.");
                Client_OnLog(sender, new OnLogArgs
                {
                    BotUsername = BotName,
                    Data = $"Bot connected to {ChannelName}.",
                    DateTime = DateTime.Now
                });
        }

        public virtual void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            string message = e.ChatMessage.Message;
            Client_OnLog(sender, new OnLogArgs
            {
                BotUsername = BotName,
                Data = $"{e.ChatMessage.Username} writed: \"{message}\".",
                DateTime = DateTime.Now
            });
            CreateAnswer(message, e.ChatMessage.Channel);
            //if (Client.UserType == UserType.Viewer && !Client.HasVIP)
            //    System.Threading.Thread.Sleep(1000);
        }

        public virtual void CreateAnswer(string message, string channel)
        {
            //!dance
            if (message.StartsWith("!dance"))
            {
                List<string> danceSmiles = new List<string>
                    { "annkraDisco", "karterDaance", "mcaT", "karterHype" };
                StringBuilder builder = new StringBuilder();
                int count = new Random().Next(20, 30);
                for (int i = 0; i < count; i++)
                {
                    builder.Append($"{danceSmiles[i % danceSmiles.Count]} ");
                }
                if (Client.Client.JoinedChannels.Count == 0)
                    Client.Client.JoinChannel(ChannelName);
                Client.Client.SendMessage(channel, builder.ToString());
            }
        }

        public virtual void Disconnect()
        {
            if (Client.Client.JoinedChannels.Count == 0)
                Client.Client.JoinChannel(ChannelName);
            Client.Client.Disconnect();
            Client_OnLog(null, new OnLogArgs
            {
                BotUsername = BotName,
                Data = $"Bot disconnected from {ChannelName}.",
                DateTime = DateTime.Now
            });
        }
    }
}
