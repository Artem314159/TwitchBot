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
        string ChannelName { get; set; }
        List<Models.CommandModel> Commands { get; set; }
        void InitializeCommands();
        void Disconnect();
    }
}
