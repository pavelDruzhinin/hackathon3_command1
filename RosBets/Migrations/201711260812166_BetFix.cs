namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BetFix : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bets", "MatchId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bets", "MatchId", c => c.Int(nullable: false));
        }
    }
}
