namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseRework : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BetsDetails", "BetsId", "dbo.Bets");
            DropForeignKey("dbo.ResultDetails", "ResultId", "dbo.Results");
            DropIndex("dbo.BetsDetails", new[] { "BetsId" });
            DropIndex("dbo.ResultDetails", new[] { "ResultId" });
            CreateTable(
                "dbo.BetEvents",
                c => new
                    {
                        BetId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.BetId, t.EventId })
                .ForeignKey("dbo.Bets", t => t.BetId, cascadeDelete: true)
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .Index(t => t.BetId)
                .Index(t => t.EventId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Team1Name = c.String(),
                        Team2Name = c.String(),
                        Date = c.DateTime(),
                        Championship = c.String(),
                        Finished = c.Boolean(nullable: false),
                        Team1Score = c.Int(nullable: false),
                        Team2Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Shortname = c.String(),
                        FullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MatchEvents",
                c => new
                    {
                        MatchId = c.Int(nullable: false),
                        EventId = c.Int(nullable: false),
                        EventValue = c.Single(nullable: false),
                    })
                .PrimaryKey(t => new { t.MatchId, t.EventId })
                .ForeignKey("dbo.Events", t => t.EventId, cascadeDelete: true)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .Index(t => t.MatchId)
                .Index(t => t.EventId);
            
            AddColumn("dbo.Bets", "MatchId", c => c.Int(nullable: false));
            AddColumn("dbo.Bets", "TotalCoefficient", c => c.Single(nullable: false));
            AddColumn("dbo.Bets", "Payout", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Bets", "BetAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "Money", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Bets", "MatchId");
            AddForeignKey("dbo.Bets", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
            DropColumn("dbo.Bets", "ToPayoff");
            DropTable("dbo.BetsDetails");
            DropTable("dbo.LineFootballs");
            DropTable("dbo.ResultDetails");
            DropTable("dbo.Results");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => new { t.ResultId, t.Event });
            
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
                .PrimaryKey(t => new { t.BetsId, t.Event });
            
            AddColumn("dbo.Bets", "ToPayoff", c => c.Single());
            DropForeignKey("dbo.MatchEvents", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.MatchEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.BetEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.Bets", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.BetEvents", "BetId", "dbo.Bets");
            DropIndex("dbo.MatchEvents", new[] { "EventId" });
            DropIndex("dbo.MatchEvents", new[] { "MatchId" });
            DropIndex("dbo.Bets", new[] { "MatchId" });
            DropIndex("dbo.BetEvents", new[] { "EventId" });
            DropIndex("dbo.BetEvents", new[] { "BetId" });
            AlterColumn("dbo.Users", "Money", c => c.Single(nullable: false));
            AlterColumn("dbo.Bets", "BetAmount", c => c.Single(nullable: false));
            DropColumn("dbo.Bets", "Payout");
            DropColumn("dbo.Bets", "TotalCoefficient");
            DropColumn("dbo.Bets", "MatchId");
            DropTable("dbo.MatchEvents");
            DropTable("dbo.Events");
            DropTable("dbo.Matches");
            DropTable("dbo.BetEvents");
            CreateIndex("dbo.ResultDetails", "ResultId");
            CreateIndex("dbo.BetsDetails", "BetsId");
            AddForeignKey("dbo.ResultDetails", "ResultId", "dbo.Results", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BetsDetails", "BetsId", "dbo.Bets", "Id", cascadeDelete: true);
        }
    }
}
