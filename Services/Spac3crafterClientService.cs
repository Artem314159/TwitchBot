using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchBot.Models;
using TwitchLib.Client.Events;

namespace TwitchBot.Services
{
    public class Spac3crafterClientService : RussianClientService
    {
        public Spac3crafterClientService(Data.BotContext db, string botName, string botToken, string channelName) 
            : base(db, botName, botToken, channelName)
        {
        }

        public override void InitializeCommands()
        {
            List<string> dance = new List<string> { "!dance" };
            Commands.Add(new CommandModel(nameof(dance), dance, "Dance, bot, dance. More than ever did not dance.", CommandPermission.All,
                command: (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(dance, lowerMessage, () =>
                    {
                        List<string> danceSmiles = new List<string>
                            { "garyParrot", "mcatDance", "PartyParrot", "ClownHypers", "AqulaWave" };
                        StringBuilder builder = new StringBuilder();
                        int count = new Random().Next(30, 40);
                        for (int i = 0; i < count; i++)
                        {
                            builder.Append($"{danceSmiles[i % danceSmiles.Count]} ");
                        }
                        if (Client.Client.JoinedChannels.Count == 0)
                            Client.Client.JoinChannel(ChannelName);
                        Client.Client.SendMessage(channel, builder.ToString());
                    });
                }));

            List<string> tg = new List<string> { "!tg" };
            Commands.Add(new CommandModel(nameof(tg), tg, "Группа телеграма для общения.", CommandPermission.All,
                command: (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(tg, lowerMessage, () =>
                    {
                        Client.Client.SendMessage(channel,
                            "Присоединяйся к нашему клубу анонимных космонавтов - https://t.me/spac3crafter_Orbit");
                    });
                }));

            List<string> tg_music = new List<string> { "!tg_music" };
            Commands.Add(new CommandModel(nameof(tg_music), tg_music, "Группа телеграма для добавления музыки.", CommandPermission.All,
                command: (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(tg_music, lowerMessage, () =>
                    {
                        Client.Client.SendMessage(channel,
                            "У тебя есть классный трек, который ты хочешь услышать на стриме? Кидай его сюда - https://t.me/joinchat/GqCB8BQi1CG1cjpep7Xy1w");
                    });
                }));
            
            List<string> discord = new List<string> { "!discord" };
            Commands.Add(new CommandModel(nameof(discord), discord, "Группа в дискорде.", CommandPermission.All,
                command: (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(discord, lowerMessage, () =>
                    {
                        Client.Client.SendMessage(channel,
                            "Приходи общаться суда - https://discord.gg/rQfxjkP");
                    });
                }));

            List<string> sasi = new List<string> { "sasi jepu", "sasi jepy" };
            Commands.Add(new CommandModel(nameof(sasi), sasi, "Группа телеграма для общения.", CommandPermission.All,
                command: (chatMessage, lowerMessage, channel) =>
                {
                    StandartCheckingMessage(sasi, lowerMessage, () =>
                    {
                        Client.Client.SendMessage(channel,
                            $"{chatMessage.Username} SAM SASI JEPY");
                    });
                }));

            base.InitializeCommands();
        }
    }
}
