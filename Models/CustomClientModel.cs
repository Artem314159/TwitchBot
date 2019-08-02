﻿using TwitchLib.Client.Enums;
using TwitchLib.Client.Interfaces;

namespace TwitchBot
{
    public class CustomClientModel
    {
        public CustomClientModel(ITwitchClient client)
        {
            Client = client;
        }

        public ITwitchClient Client { get; set; }
        public bool IsSub { get; set; }
        public bool HasVIP { get; set; }
        public UserType UserType { get; set; }
        public bool Works { get; set; } = false;
    }
}