using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot.Data
{
    [Table("Friend")]
    public class Friend : NamedEntity
    {
        public virtual ICollection<HiFriendHistory> HiFriendHistories { get; set; }

    }
}
