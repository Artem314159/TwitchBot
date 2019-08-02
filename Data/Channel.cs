using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot.Data
{
    [Table("Channel")]
    public class Channel : NamedEntity
    {
        public Channel()
        {
            HiFriendHistories = new HashSet<HiFriendHistory>();
        }

        [Column]
        public Language ChannelLanguage { get; set; }
        [Column]
        public bool StartOnLoading { get; set; }

        public virtual ICollection<HiFriendHistory> HiFriendHistories { get; set; }
    }
}
