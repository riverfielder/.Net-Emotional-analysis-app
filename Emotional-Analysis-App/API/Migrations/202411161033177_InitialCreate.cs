namespace API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmotionRecords",
                c => new
                    {
                        RecordId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Text = c.String(),
                        Sentiment = c.Int(nullable: false),
                        Confidence = c.Double(nullable: false),
                        PositiveProbability = c.Double(nullable: false),
                        NegativeProbability = c.Double(nullable: false),
                        RecordedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RecordId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        PasswordHash = c.String(),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.KeywordFrequencies",
                c => new
                    {
                        KeywordId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Keyword = c.String(),
                        Frequency = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.KeywordId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmotionRecords", "UserId", "dbo.Users");
            DropForeignKey("dbo.KeywordFrequencies", "UserId", "dbo.Users");
            DropIndex("dbo.KeywordFrequencies", new[] { "UserId" });
            DropIndex("dbo.EmotionRecords", new[] { "UserId" });
            DropTable("dbo.KeywordFrequencies");
            DropTable("dbo.Users");
            DropTable("dbo.EmotionRecords");
        }
    }
}
