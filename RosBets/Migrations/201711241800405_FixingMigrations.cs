namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingMigrations : DbMigration
    {
        public override void Up()
        {
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
                "dbo.Bets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        MatchId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Success = c.Boolean(),
                        BetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCoefficient = c.Single(nullable: false),
                        Payout = c.Decimal(precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Matches", t => t.MatchId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.MatchId);
            
            CreateTable(
                "dbo.Matches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MatchNumber = c.Int(nullable: false),
                        MatchName = c.String(),
                        Team1Name = c.String(),
                        Team2Name = c.String(),
                        Date = c.DateTime(),
                        Finished = c.Boolean(nullable: false),
                        Team1Score = c.Int(),
                        Team2Score = c.Int(),
                        ChampionshipId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Championships", t => t.ChampionshipId, cascadeDelete: true)
                .Index(t => t.ChampionshipId);
            
            CreateTable(
                "dbo.Championships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sports", t => t.SportId, cascadeDelete: true)
                .Index(t => t.SportId);
            
            CreateTable(
                "dbo.Sports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        MiddleName = c.String(nullable: false),
                        Mail = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        City = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Money = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bets", "UserId", "dbo.Users");
            DropForeignKey("dbo.MatchEvents", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.MatchEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.BetEvents", "EventId", "dbo.Events");
            DropForeignKey("dbo.Championships", "SportId", "dbo.Sports");
            DropForeignKey("dbo.Matches", "ChampionshipId", "dbo.Championships");
            DropForeignKey("dbo.Bets", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.BetEvents", "BetId", "dbo.Bets");
            DropIndex("dbo.MatchEvents", new[] { "EventId" });
            DropIndex("dbo.MatchEvents", new[] { "MatchId" });
            DropIndex("dbo.Championships", new[] { "SportId" });
            DropIndex("dbo.Matches", new[] { "ChampionshipId" });
            DropIndex("dbo.Bets", new[] { "MatchId" });
            DropIndex("dbo.Bets", new[] { "UserId" });
            DropIndex("dbo.BetEvents", new[] { "EventId" });
            DropIndex("dbo.BetEvents", new[] { "BetId" });
            DropTable("dbo.Users");
            DropTable("dbo.Events");
            DropTable("dbo.MatchEvents");
            DropTable("dbo.Sports");
            DropTable("dbo.Championships");
            DropTable("dbo.Matches");
            DropTable("dbo.Bets");
            DropTable("dbo.BetEvents");
        }
    }
}
