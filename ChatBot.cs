using System;
using System.Collections.Generic;
using System.Text;
using TwitchLib.Api;
using TwitchLib.Api.V5.Models.Subscriptions;
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;
using TwitchLib.Communication.Clients;
using TwitchLib.Communication.Models;

namespace TwitchBot
{
    internal class ChatBot
    {
        public ConnectionCredentials Credentials { get; set; }
        TwitchClient Client { get; set; }

        internal void Connect(string botName, string botToken, List<string> channels)
        {
            //TwitchAPI api = new TwitchAPI();
            //api.Settings.ClientId = "client_id";
            //api.Settings.AccessToken = "access_token";
            //Subscription subscription = await api.V5.Channels.CheckChannelSubscriptionByUserAsync("channel_id", "user_id");

            Credentials = new ConnectionCredentials(botName, botToken);

            var clientOptions = new ClientOptions
            {
                MessagesAllowedInPeriod = 100,
                ThrottlingPeriod = TimeSpan.FromSeconds(60)
            };
            var customClient = new WebSocketClient(clientOptions);

            Client = new TwitchClient(customClient);
            Client.Initialize(Credentials, "ba_ba_yka");

            Client.OnMessageReceived += Client_OnMessageReceived;
            Client.OnJoinedChannel += Client_OnJoinedChannel;

            Client.Connect();
            foreach (var channel in channels)
            {
                Client.JoinChannel(channel);
            }
        }

        private void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e)
        {
            Client.SendMessage(e.Channel, "Hello everybody! annkraHello");
        }

        private void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e)
        {
            string message = e.ChatMessage.Message;

            //!dance
            if (message.StartsWith("!dance"))
            {
                List<string> danceSmiles = new List<string> { "annkraDisco", "karterDaance", "mcaT", "karterHype" };
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < 25; i++)
                {
                    builder.Append($"{danceSmiles[i % danceSmiles.Count]} ");
                }
                Client.SendMessage(e.ChatMessage.Channel, builder.ToString());
            }
        }

        internal void Disconnect()
        {
            Client.Disconnect();
        }
    }
}