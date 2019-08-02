using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot.Services
{
    public class Vika_KarterClientService : RussianClientService
    {
        public Vika_KarterClientService(Data.BotContext db, string botName, string botToken, string channelName)
            : base(db, botName, botToken, channelName)
        { }

        public override void InitializeCommands()
        { }
    }
}
