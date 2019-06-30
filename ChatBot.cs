using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Api;
using TwitchLib.Client;
using TwitchLib.Client.Enums;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Events;

namespace TwitchBot
{
    internal class ChatBot
    {
        private ConnectionCredentials Credentials { get; set; }
        private List<CustomClientModel> Clients { get; set; } = new List<CustomClientModel>();

        public event EventHandler<OnLogArgs> OnLog;

        internal void Connect(string botName, string botToken, List<string> channels)
        {
            //var api = new TwitchAPI();
            //api.Settings.ClientId = GetUserId(botName).Result;
            //api.Settings.AccessToken = botToken;

            foreach (var channel in channels)
            {
                Credentials = new ConnectionCredentials(botName, botToken);
                var client = new TwitchClient();
                client.Initialize(Credentials, channel);

                var model = new CustomClientModel(client);
                Clients.Add(model);

                //is posible because model contain property "client"
                client.OnConnected += (s, ev) => Client_OnConnected(model, ev);
                client.OnMessageReceived += (s, ev) => Client_OnMessageReceived(model, ev);
                client.OnJoinedChannel += (s, ev) => Client_OnJoinedChannel(model, ev);
                client.OnUserStateChanged += (s, ev) => Client_OnUserStateChanged(model, ev);
                client.OnMessageThrottled += (s, ev) => Client_OnMessageThrottled(model, ev);
                client.OnLog += Client_OnLog;

                client.Connect();
                //var channelFollowers = api.V5.Channels.GetChannelFollowersAsync(channel).Result;
            }
        }

        public static async Task<string> GetUserId(string name)
        {
            var api = new TwitchAPI();
            var userList = await api.V5.Users.GetUserByNameAsync(name);
            if (userList == null || userList.Total == 0)
                return string.Empty;
            else
                return userList.Matches[0].Id.Trim();
        }

        private void Client_OnMessageThrottled(object sender, OnMessageThrottledEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Client_OnLog(object sender, OnLogArgs e)
        {
            this.OnLog?.Invoke(sender, e);
        }

        private void Client_OnUserStateChanged(object sender, OnUserStateChangedArgs e)
        {
            var clientModel = Clients.First(_ => 
                _.ChannelName == (sender as CustomClientModel).ChannelName);
            clientModel.UserType = e.UserState.UserType;
            clientModel.IsSub = e.UserState.IsSubscriber;
            clientModel.HasVIP = e.UserState.Badges.Any(_ => _.Key == "vip");
        }

        /*internal void Connect(string botName, string botToken, string channel)
        {
            Credentials = new ConnectionCredentials(botName, botToken);

            Client = new TwitchClient();
            Client.Initialize(Credentials, channel);

            Client.OnConnected += Client_OnConnected;
            Client.OnMessageReceived += Client_OnMessageReceived;
            Client.OnJoinedChannel += Client_OnJoinedChannel;
            Client.OnModeratorsReceived += Client_OnModeratorsReceived;
            Client.OnVIPsReceived += Client_OnVIPsReceived;

            Client.Connect();
            while (true)
            {
                try
                {
                    Client.GetVIPs(channel);
                    Client.GetChannelModerators(channel);
                    break;
                }
                catch (Exception e) { }
            }
        }*/

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            var model = Clients.First(_ =>
                _.ChannelName == (sender as CustomClientModel).ChannelName);
            if (model.Client.JoinedChannels.Any(_ => _.Channel == e.Channel))
                model.Client.SendMessage(e.Channel, "Bot joined.");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            var model = Clients.First(_ =>
                _.ChannelName == (sender as CustomClientModel).ChannelName);
            model.ChannelName = model.Client.JoinedChannels[0].Channel;
            if (model.Client.JoinedChannels.Any(_ => _.Channel == e.AutoJoinChannel))
                model.Client.SendMessage(e.AutoJoinChannel, "Bot connected.");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            var model = Clients.First(_ =>
                _.ChannelName == (sender as CustomClientModel).ChannelName);
            if (model.UserType == UserType.Viewer && !model.HasVIP)
                System.Threading.Thread.Sleep(1000);
            string message = e.ChatMessage.Message;

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
                model.Client.SendMessage(e.ChatMessage.Channel, builder.ToString());
            }
        }

        internal void Disconnect()
        {
            foreach (var client in Clients)
            {
                client.Client.Disconnect();
            }
            Clients.Clear();
        }
    }
}