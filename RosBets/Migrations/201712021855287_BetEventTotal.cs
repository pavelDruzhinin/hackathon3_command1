namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BetEventTotal : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BetEvents", "Total", c => c.Single());
            AddColumn("dbo.CouponEvents", "Total", c => c.Single());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CouponEvents", "Total");
            DropColumn("dbo.BetEvents", "Total");
        }
    }
}
