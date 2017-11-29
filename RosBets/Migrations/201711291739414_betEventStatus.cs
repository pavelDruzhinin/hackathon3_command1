namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class betEventStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BetEventStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.BetEvents", "BetEventStatusId", c => c.Int());
            CreateIndex("dbo.BetEvents", "BetEventStatusId");
            AddForeignKey("dbo.BetEvents", "BetEventStatusId", "dbo.BetEventStatus", "Id");
            DropColumn("dbo.BetEvents", "Success");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BetEvents", "Success", c => c.Boolean());
            DropForeignKey("dbo.BetEvents", "BetEventStatusId", "dbo.BetEventStatus");
            DropIndex("dbo.BetEvents", new[] { "BetEventStatusId" });
            DropColumn("dbo.BetEvents", "BetEventStatusId");
            DropTable("dbo.BetEventStatus");
        }
    }
}
