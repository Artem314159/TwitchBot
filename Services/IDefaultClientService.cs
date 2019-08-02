using System;
using System.Collections.Generic;
using TwitchLib.Client.Events;

namespace TwitchBot
{
    public interface IDefaultClientService
    {
        event EventHandler<OnLogArgs> OnLog;
        string ChannelName { get; set; }
        CustomClientModel Client { get; }
        List<Models.CommandModel> Commands { get; set; }
        void InitializeCommands();
        void Disconnect();
    }
}
