namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BetEventSuccess : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BetEvents", "Success", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.BetEvents", "Success");
        }
    }
}
