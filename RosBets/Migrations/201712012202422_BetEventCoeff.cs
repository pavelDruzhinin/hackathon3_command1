namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BetEventCoeff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CouponEvents",
                c => new
                    {
                        MatchId = c.Int(),
                        EventId = c.Int(),
                        Id = c.Int(nullable: false, identity: true),
                        Coupon = c.String(),
                        Coefficient = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.Matches", t => t.MatchId)
                .ForeignKey("dbo.MatchEvents", t => new { t.MatchId, t.EventId })
                .Index(t => t.MatchId)
                .Index(t => new { t.MatchId, t.EventId })
                .Index(t => t.EventId);
            
            AddColumn("dbo.BetEvents", "Coefficient", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CouponEvents", new[] { "MatchId", "EventId" }, "dbo.MatchEvents");
            DropForeignKey("dbo.CouponEvents", "MatchId", "dbo.Matches");
            DropForeignKey("dbo.CouponEvents", "EventId", "dbo.Events");
            DropIndex("dbo.CouponEvents", new[] { "EventId" });
            DropIndex("dbo.CouponEvents", new[] { "MatchId", "EventId" });
            DropIndex("dbo.CouponEvents", new[] { "MatchId" });
            DropColumn("dbo.BetEvents", "Coefficient");
            DropTable("dbo.CouponEvents");
        }
    }
}
