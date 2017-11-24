namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BetsDetails",
                c => new
                    {
                        BetsId = c.Int(nullable: false),
                        Event = c.String(nullable: false, maxLength: 128),
                        Championat = c.String(maxLength: 448),
                        Cef = c.Single(nullable: false),
                        Success = c.Boolean(),
                        P1 = c.Boolean(nullable: false),
                        X = c.Boolean(nullable: false),
                        P2 = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.BetsId, t.Event })
                .ForeignKey("dbo.Bets", t => t.BetsId, cascadeDelete: true)
                .Index(t => t.BetsId);
            
            CreateTable(
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Success = c.Boolean(),
                        ToPayoff = c.Single(),
                        BetAmount = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Mail = c.String(),
                        Phone = c.String(),
                        City = c.String(),
                        Password = c.String(),
                        Money = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LineFootballs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdGames = c.String(),
                        Date = c.DateTime(),
                        Championat = c.String(),
                        Event = c.String(),
                        P1 = c.Single(),
                        X = c.Single(),
                        P2 = c.Single(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ResultDetails",
                c => new
                    {
                        ResultId = c.Int(nullable: false),
                        Event = c.String(nullable: false, maxLength: 128),
                        Championat = c.String(maxLength: 448),
                        FirstWin = c.Boolean(),
                        SecondWin = c.Boolean(),
                        Draw = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.ResultId, t.Event })
                .ForeignKey("dbo.Results", t => t.ResultId, cascadeDelete: true)
                .Index(t => t.ResultId);
            
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Championat = c.String(),
                        Event = c.String(),
                        FirstResult = c.Int(nullable: false),
                        SecondResult = c.Int(nullable: false),
                        Calculated = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ResultDetails", "ResultId", "dbo.Results");
            DropForeignKey("dbo.Bets", "UserId", "dbo.Users");
            DropForeignKey("dbo.BetsDetails", "BetsId", "dbo.Bets");
            DropIndex("dbo.ResultDetails", new[] { "ResultId" });
            DropIndex("dbo.Bets", new[] { "UserId" });
            DropIndex("dbo.BetsDetails", new[] { "BetsId" });
            DropTable("dbo.Results");
            DropTable("dbo.ResultDetails");
            DropTable("dbo.LineFootballs");
            DropTable("dbo.Users");
            DropTable("dbo.Bets");
            DropTable("dbo.BetsDetails");
        }
    }
}
