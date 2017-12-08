namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Pay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        Sum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sender = c.String(),
                        Operation_Id = c.String(),
                        Amount = c.Decimal(precision: 18, scale: 2),
                        WithdrawAmount = c.Decimal(precision: 18, scale: 2),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pays", "UserId", "dbo.Users");
            DropIndex("dbo.Pays", new[] { "UserId" });
            DropTable("dbo.Pays");
        }
    }
}
