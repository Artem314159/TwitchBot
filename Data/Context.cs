using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchBot.Data
{
    public class BotContext : DbContext
    {
        public BotContext() : base("name=ConnectionString")
        { }
        
        public BotContext(string stringConnection) : base(stringConnection)
        { }

        public BotContext(DbConnection connection) : base(connection, false)
        { }
        
        public DbSet<Channel> Channels { get; set; }
        public DbSet<BotCredential> BotCredentials { get; set; }
        public DbSet<Friend> Friends { get; set; }
        public DbSet<HiFriendHistory> HiFriendHistorys { get; set; }
    }
}
