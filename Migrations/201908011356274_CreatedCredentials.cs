namespace TwitchBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedCredentials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BotCredential",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Token = c.String(),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Channel", "ChannelLanguage", c => c.Int(nullable: false));
            AddColumn("dbo.Channel", "StartOnLoading", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Channel", "StartOnLoading");
            DropColumn("dbo.Channel", "ChannelLanguage");
            DropTable("dbo.BotCredential");
        }
    }
}
