using System;
using System.Collections.Generic;
using TwitchLib.Client.Models;

namespace TwitchBot.Models
{
    public class CommandModel
    {
        public List<string> Names { get; set; }
        public string Description { get; set; }
        public Action<ChatMessage, string, string> Command { get; set; }
    }
}
