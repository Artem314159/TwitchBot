namespace TwitchBot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedHiHistory : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Friends", newName: "Friend");
            CreateTable(
                "dbo.HiFriendHistory",
                c => new
                    {
                        FriendId = c.Int(nullable: false),
                        ChannelId = c.Int(nullable: false),
                        LastHiDate = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => new { t.FriendId, t.ChannelId })
                .ForeignKey("dbo.Channel", t => t.ChannelId, cascadeDelete: true)
                .ForeignKey("dbo.Friend", t => t.FriendId, cascadeDelete: true)
                .Index(t => t.FriendId)
                .Index(t => t.ChannelId);
            
            CreateTable(
                "dbo.Channel",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HiFriendHistory", "FriendId", "dbo.Friend");
            DropForeignKey("dbo.HiFriendHistory", "ChannelId", "dbo.Channel");
            DropIndex("dbo.HiFriendHistory", new[] { "ChannelId" });
            DropIndex("dbo.HiFriendHistory", new[] { "FriendId" });
            DropTable("dbo.Channel");
            DropTable("dbo.HiFriendHistory");
            RenameTable(name: "dbo.Friend", newName: "Friends");
        }
    }
}
