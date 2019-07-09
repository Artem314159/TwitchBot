using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Events;

namespace TwitchBot
{
    public interface IDefaultClientService
    {
        event EventHandler<OnLogArgs> OnLog;
        //void Client_OnLog(object sender, OnLogArgs e);
        void Client_OnUserStateChanged(object sender, OnUserStateChangedArgs e);
        void Client_OnJoinedChannel(object sender, OnJoinedChannelArgs e);
        void Client_OnConnected(object sender, OnConnectedArgs e);
        void Client_OnMessageReceived(object sender, OnMessageReceivedArgs e);
        void CreateAnswer(string message, string channel);
        void Disconnect();
    }
}
