using System;
using System.Collections.Generic;
using TwitchLib.Client.Models;

namespace TwitchBot.Models
{
    public class CommandModel
    {
        public CommandModel(string name, List<string> words, string description, CommandPermission commandPermission, Action<ChatMessage, string, string> command)
        {
            Name = name;
            Words = words;
            Description = description;
            CommandPermission = commandPermission;
            Command = command;
        }

        public string Name { get; set; }
        public List<string> Words { get; set; }
        public string Description { get; set; }
        public CommandPermission CommandPermission { get; set; }
        public Action<ChatMessage, string, string> Command { get; set; }
    }

    [Flags]
    public enum CommandPermission
    {
        Viewer = 0x01,
        Sub = 0x02,
        Vip = 0x04,
        Moder = 0x08,
        Self = 0x10,
        Broadcaster = 0x20,
        WithoutTimeOut = Vip | Moder | Broadcaster,
        All = Viewer | Sub | Vip | Moder | Self | Broadcaster
    }
}
