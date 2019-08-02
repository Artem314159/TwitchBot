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
        public RussianClientService(Data.BotContext db, string botName, string botToken, string channelName) : base(db, botName, botToken, channelName)
        {
        }

        public override void InitializeCommands()
        {
            List<string> ass = new List<string> { "!попа", "!жопа", "!ass" };
            Commands.Add(new CommandModel(nameof(ass), ass, "Проверь, насколько ты отъел свою жопу Kappa .", CommandPermission.All,
                command: (chatMessage, lowerMessage, channel) =>
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
                        if (chatMessage.Username.ToLower() == "excitedtwin")
                            res = "Уууу, ну и жирная у тебя жопа, Кира, опять после 6 ела, да? PixelBob ХАРЕ ЖРАТЬ, иди кусты рисуй Keepo";
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
                                if (target.ToLower().Contains("excitedtwin"))
                                    res = "Уууу, ну и жирная у тебя жопа, Кира, опять после 6 ела, да? PixelBob ХАРЕ ЖРАТЬ, иди кусты рисуй Keepo";
                                Client.Client.SendMessage(channel, $"{target}, {res}");
                                break;
                            }
                        }
                }));

            base.InitializeCommands();
        }
    }
}
