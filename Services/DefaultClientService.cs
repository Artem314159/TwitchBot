using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchBot.Models;
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
        public string ChannelName { get; set; }

        public List<CommandModel> Commands { get; set; } = new List<CommandModel>();

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
            client.OnDisconnected += (s, ev) => Client_OnDisconnected(Client, ev);

            InitializeCommands();

            client.Connect();
        }

        private void Client_OnDisconnected(object sender, OnDisconnectedEventArgs e)
        {
            Client_OnLog(null, new OnLogArgs
            {
                BotUsername = BotName,
                Data = $"Bot disconnected from {ChannelName}.",
                DateTime = DateTime.Now
            });
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
            if (e.UserState.Channel.ToLower() == BotName.ToLower()) Client.UserType = UserType.Broadcaster;
            Client.IsSub = e.UserState.IsSubscriber;
            Client.HasVIP = e.UserState.Badges.Any(_ => _.Key == "vip");
        }

        public virtual void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
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

            Client_OnLog(sender, new OnLogArgs
            {
                BotUsername = BotName,
                Data = $"Bot connected to {ChannelName}.",
                DateTime = DateTime.Now
            });
        }

        public virtual void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            var chatMessage = e.ChatMessage;
            Client_OnLog(sender, new OnLogArgs
            {
                BotUsername = BotName,
                Data = $"({ChannelName}) {chatMessage.Username}: \"{chatMessage.Message}\".",
                DateTime = DateTime.Now
            });
            if (Client.UserType == UserType.Viewer && !Client.HasVIP)
                System.Threading.Thread.Sleep(1000);

            var lowerMessage = chatMessage.Message.ToLower();
            Commands.ForEach(_ => _.Command?.Invoke(chatMessage, lowerMessage, ChannelName));
        }

        public virtual void InitializeCommands()
        {
            List<string> dance = new List<string> { "!dance" };
            Commands.Add(new CommandModel
            {
                Names =  dance,
                Description = "Dance, bot, dance. More than ever did not dance.",
                Command = (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(dance, lowerMessage, () =>
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
                    });
                }
            });

            List<string> help = new List<string> { "!help" };
            Commands.Add(new CommandModel
            {
                Names = help,
                Description = "Returns all bot commands for this channel.",
                Command = (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(help, lowerMessage, () =>
                    {
                        StringBuilder builder = new StringBuilder("Available commands: PurpleStar ");
                        foreach (var command in Commands)
                        {
                            int count = command.Names.Count;
                            builder.Append(command.Names[0]);
                            for (int i = 1; i < count; i++)
                                builder.Append($", {command.Names[i]}");
                            builder.Append($" - {command.Description} PurpleStar ");
                        }
                        if (Client.Client.JoinedChannels.Count == 0)
                            Client.Client.JoinChannel(ChannelName);
                        Client.Client.SendMessage(channel, builder.ToString());
                    });
                }
            });
        }

        protected void StandartCheckingMessage(List<string> names, string lowerMessage, Action f)
        {
            if (names.Contains(lowerMessage) || names.Any(_ => lowerMessage.StartsWith($"{_} ")))
            {
                f?.Invoke();
            }
        } 

        public virtual void Disconnect()
        {
            if (Client.Client.IsConnected)
            {
                if (Client.Client.JoinedChannels.Count == 0)
                    Client.Client.JoinChannel(ChannelName);
                Client.Client.Disconnect();
            }
        }
    }
}
