using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot.Data
{
    [Table("BotCredential")]
    public class BotCredential : NamedEntity
    {
        [Column]
        public string Token { get; set; }
    }
}
