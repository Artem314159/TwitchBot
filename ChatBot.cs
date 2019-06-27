using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Subscriptions;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Extensions;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace TwitchBot
{
    internal class ChatBot
    {
        private ConnectionCredentials Credentials { get; set; }
        //private List<TwitchClient> Clients { get; set; } = new List<TwitchClient>();
        private TwitchClient Client { get; set; }
        public bool IsModerOrVIP { get; set; }

        /*internal void Connect(string botName, string botToken, List<string> channels)
        {
            Credentials = new ConnectionCredentials(botName, botToken);

            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 100,
                ThrottlingPeriod = TimeSpan.FromSeconds(60)
            };
            var customClient = new WebSocketClient(clientOptions);

            foreach (var channel in channels)
            {
                var client = new TwitchClient();
                client.Initialize(Credentials, channel);

                client.OnConnected += Client_OnConnected;
                client.OnMessageReceived += Client_OnMessageReceived;
                client.OnJoinedChannel += Client_OnJoinedChannel;

                client.Connect();
                Clients.Add(client);
            }
        }*/

        internal void Connect(string botName, string botToken, string channel)
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
        }

        private void Client_OnModeratorsReceived(object sender, OnModeratorsReceivedArgs e)
        {
            IsModerOrVIP = IsModerOrVIP || e.Moderators.Contains(Client.ConnectionCredentials.TwitchUsername);
        }

        private void Client_OnVIPsReceived(object sender, OnVIPsReceivedArgs e)
        {
            IsModerOrVIP = IsModerOrVIP || e.VIPs.Contains(Client.ConnectionCredentials.TwitchUsername);
        }

        private void CheckClientChannel(TwitchClient client, string channel)
        {
            if (!client.JoinedChannels.Any(_ => _.Channel == channel))
                client.JoinChannel(channel);
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            //var client = (sender as TwitchClient);
            //CheckClientChannel(client, e.Channel);
            //if (client.JoinedChannels.Any(_ => _.Channel == e.Channel))
                //Client.SendMessage(e.Channel, "Bot joined MrDestructoid");
        }

        private void Client_OnConnected(object sender, OnConnectedArgs e)
        {
            //var client = (sender as TwitchClient);
            //CheckClientChannel(client, e.AutoJoinChannel);
            //if (client.JoinedChannels.Any(_ => _.Channel == e.AutoJoinChannel))
                //Client.SendMessage(e.AutoJoinChannel, "Bot connected MrDestructoid");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            if(!IsModerOrVIP)
                System.Threading.Thread.Sleep(1000);
            string message = e.ChatMessage.Message;

            //!dance
            if (message == "!dance")
            {
                List<string> danceSmiles = new List<string> { "annkraDisco", "karterDaance", "mcaT", "karterHype" };
                StringBuilder builder = new StringBuilder();
                int count = new Random().Next(20, 30);
                for (int i = 0; i < count; i++)
                {
                    builder.Append($"{danceSmiles[i % danceSmiles.Count]} ");
                }
                //var client = (sender as TwitchClient);
                //CheckClientChannel(client, e.ChatMessage.Channel);
                //if (client.JoinedChannels.Any(_ => _.Channel == e.ChatMessage.Channel))
                //string s = "annkraDisco karterDaance mcaT karterHype annkraDisco karterDaance mcaT karterHype annkraDisco karterDaance mcaT karterHype annkraDisco karterDaance mcaT karterHype annkraDisco karterDaance mcaT karterHype ";
                    Client.SendMessage(e.ChatMessage.Channel, builder.ToString());
            }
        }

        internal void Disconnect()
        {
            //foreach (var client in Clients)
            //{
                Client.Disconnect();
            //}
            IsModerOrVIP = false;
        }
    }
}