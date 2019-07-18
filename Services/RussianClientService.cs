using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitchBot.Models;
using TwitchLib.Client.Enums;

namespace TwitchBot.Services
{
    public class RussianClientService : DefaultClientService
    {
        public RussianClientService(string botName, string botToken, string channelName) : base(botName, botToken, channelName)
        {
        }

        public override void InitializeCommands()
        {
            List<string> ass = new List<string> { "!жопа", "!ass" };
            Commands.Add(new CommandModel
            {
                Names = ass,
                Description = "Проверь, насколько ты отъел свою жопу Kappa .",
                Command = (chatMessage, lowerMessage, channel) =>
                {
                    var levels = new List<string> {
                        "NotLikeThis а где, собственно, сама жопа? Что мне щупать? :|",
                        "cmonBruh Мдааа, сходи в зал, накачай жопу, что-ли, а то как лох. PixelBob",
                        "Нууу, неплохая жопа, щупать приятно Keepo",
                        "PogChamp Оу май, какая жопень, *шлеп* ;P",
                        ":O Чегооооо, разве бывает такой пердак? Даже больше чем у Ким SeemsGood"
                    };
                    if (ass.Contains(lowerMessage))
                    {
                        Client.Client.SendMessage(channel, "Проверка жопы методом щупа... Kappa");
                        if (Client.UserType == UserType.Viewer && !Client.HasVIP)
                            System.Threading.Thread.Sleep(500);
                        System.Threading.Thread.Sleep(500);

                        string res = levels[new Random().Next(levels.Count)];
                        Client.Client.SendMessage(channel, $"{chatMessage.Username}, {res}");
                    }
                    else
                        foreach (var elem in ass)
                        {
                            if (lowerMessage.StartsWith($"{elem} "))
                            {
                                Client.Client.SendMessage(channel, "Проверка жопы методом щупа... Kappa");
                                if (Client.UserType == UserType.Viewer && !Client.HasVIP)
                                    System.Threading.Thread.Sleep(500);
                                System.Threading.Thread.Sleep(500);

                                string res = levels[new Random().Next(levels.Count)];
                                var target = chatMessage.Message.Remove(0, elem.Length + 1);
                                Client.Client.SendMessage(channel, $"{target}, {res}");
                                break;
                            }
                        }
                }
            });

            base.InitializeCommands();
        }
    }
}
