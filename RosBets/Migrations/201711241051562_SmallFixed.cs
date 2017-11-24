namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallFixed : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Championships",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Sport = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Matches", "ChampoinshipId", c => c.Int(nullable: false));
            AddColumn("dbo.Matches", "Championship_Id", c => c.Int());
            AlterColumn("dbo.Matches", "Team1Score", c => c.Int());
            AlterColumn("dbo.Matches", "Team2Score", c => c.Int());
            CreateIndex("dbo.Matches", "Championship_Id");
            AddForeignKey("dbo.Matches", "Championship_Id", "dbo.Championships", "Id");
            DropColumn("dbo.Matches", "Championship");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "Championship", c => c.String());
            DropForeignKey("dbo.Matches", "Championship_Id", "dbo.Championships");
            DropIndex("dbo.Matches", new[] { "Championship_Id" });
            AlterColumn("dbo.Matches", "Team2Score", c => c.Int(nullable: false));
            AlterColumn("dbo.Matches", "Team1Score", c => c.Int(nullable: false));
            DropColumn("dbo.Matches", "Championship_Id");
            DropColumn("dbo.Matches", "ChampoinshipId");
            DropTable("dbo.Championships");
        }
    }
}
