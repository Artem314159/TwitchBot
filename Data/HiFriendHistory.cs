using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot.Data
{
    [Table("HiFriendHistory")]
    public class HiFriendHistory
    {
        [Key, Column(Order = 0)]
        public int FriendId { get; set; }

        [Key, Column(Order = 1)]
        public int ChannelId { get; set; }

        [Column(TypeName = "date")]
        public DateTime LastHiDate { get; set; }


        [ForeignKey(nameof(FriendId))]
        public virtual Friend Friend { get; set; }

        [ForeignKey(nameof(ChannelId))]
        public virtual Channel Channel { get; set; }

    }
}
