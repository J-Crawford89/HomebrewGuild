namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notifications : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CommentId = c.Int(),
                        ReplyId = c.Int(),
                        MonsterId = c.Int(),
                        SpellId = c.Int(),
                        DateCreated = c.DateTime(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        UserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Comment", t => t.CommentId)
                .ForeignKey("dbo.Monster", t => t.MonsterId)
                .ForeignKey("dbo.Reply", t => t.ReplyId)
                .ForeignKey("dbo.Spell", t => t.SpellId)
                .Index(t => t.CommentId)
                .Index(t => t.ReplyId)
                .Index(t => t.MonsterId)
                .Index(t => t.SpellId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notification", "SpellId", "dbo.Spell");
            DropForeignKey("dbo.Notification", "ReplyId", "dbo.Reply");
            DropForeignKey("dbo.Notification", "MonsterId", "dbo.Monster");
            DropForeignKey("dbo.Notification", "CommentId", "dbo.Comment");
            DropIndex("dbo.Notification", new[] { "SpellId" });
            DropIndex("dbo.Notification", new[] { "MonsterId" });
            DropIndex("dbo.Notification", new[] { "ReplyId" });
            DropIndex("dbo.Notification", new[] { "CommentId" });
            DropTable("dbo.Notification");
        }
    }
}
