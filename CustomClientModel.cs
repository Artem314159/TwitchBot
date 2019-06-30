using TwitchLib.Client.Enums;
using TwitchLib.Client.Interfaces;

namespace TwitchBot
{
    public class CustomClientModel
    {
        public CustomClientModel(ITwitchClient client)
        {
            Client = client;
        }

        public string ChannelName { get; set; }
        public ITwitchClient Client { get; set; }
        public bool IsSub { get; set; }
        public bool HasVIP { get; set; }
        public UserType UserType { get; set; }
    }
}
