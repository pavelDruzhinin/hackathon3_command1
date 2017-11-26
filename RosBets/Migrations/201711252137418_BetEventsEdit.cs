namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BetEventsEdit : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bets", "MatchId", "dbo.Matches");
            DropIndex("dbo.Bets", new[] { "MatchId" });
            DropPrimaryKey("dbo.BetEvents");
            AddColumn("dbo.BetEvents", "MatchId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BetEvents", new[] { "BetId", "EventId", "MatchId" });
            CreateIndex("dbo.BetEvents", "MatchId");
            AddForeignKey("dbo.BetEvents", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BetEvents", "MatchId", "dbo.Matches");
            DropIndex("dbo.BetEvents", new[] { "MatchId" });
            DropPrimaryKey("dbo.BetEvents");
            DropColumn("dbo.BetEvents", "MatchId");
            AddPrimaryKey("dbo.BetEvents", new[] { "BetId", "EventId" });
            CreateIndex("dbo.Bets", "MatchId");
            AddForeignKey("dbo.Bets", "MatchId", "dbo.Matches", "Id", cascadeDelete: true);
        }
    }
}
