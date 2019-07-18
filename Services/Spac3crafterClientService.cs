using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchBot.Models;
using TwitchLib.Client.Events;

namespace TwitchBot.Services
{
    public class Spac3crafterClientService : RussianClientService
    {
        public Spac3crafterClientService(string botName, string botToken, string channelName) 
            : base(botName, botToken, channelName)
        {
        }

        public override void InitializeCommands()
        {
            List<string> tg = new List<string> { "!tg" };
            Commands.Add(new CommandModel
            {
                Names =  tg,
                Description = "Группа телеграма для общения.",
                Command = (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(tg, lowerMessage, () =>
                    {
                        Client.Client.SendMessage(channel,
                            "Присоединяйся к нашему клубу анонимных космонавтов - https://t.me/spac3crafter_Orbit");
                    });
                }
            });

            List<string> tg_music = new List<string> { "!tg_music" };
            Commands.Add(new CommandModel
            {
                Names =  tg_music,
                Description = "Группа телеграма для добавления музыки.",
                Command = (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(tg_music, lowerMessage, () =>
                    {
                        Client.Client.SendMessage(channel,
                            "У тебя есть классный трек, который ты хочешь услышать на стриме? Кидай его сюда - https://t.me/joinchat/GqCB8BQi1CG1cjpep7Xy1w");
                    });
                }
            });
            
            List<string> discord = new List<string> { "!discord" };
            Commands.Add(new CommandModel
            {
                Names =  discord,
                Description = "Группа в дискорде.",
                Command = (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(discord, lowerMessage, () =>
                    {
                        Client.Client.SendMessage(channel,
                            "Приходи общаться суда - https://discord.gg/rQfxjkP");
                    });
                }
            });

            base.InitializeCommands();
        }
    }
}
