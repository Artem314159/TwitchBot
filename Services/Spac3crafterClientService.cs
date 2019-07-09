using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchLib.Client.Events;

namespace TwitchBot.Services
{
    public class Spac3crafterClientService : DefaultClientService
    {
        public Spac3crafterClientService(string botName, string botToken, string channelName) 
            : base(botName, botToken, channelName)
        {
        }

        public override void CreateAnswer(string message, string channel)
        {
            if (message == "!tg")
                Client.Client.SendMessage(channel, 
                    "Присоединяйся к нашему клубу анонимных космонавтов - https://t.me/spac3crafter_Orbit");
            if (message == "!tg_sound")
                Client.Client.SendMessage(channel,
                    "У тебя есть классный трек, который ты хочешь услышать на стриме? Кидай его сюда - https://t.me/joinchat/GqCB8BQi1CG1cjpep7Xy1w");
            base.CreateAnswer(message, channel);
        }
    }
}
