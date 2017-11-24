namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallFixedFixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Matches", "Championship_Id", "dbo.Championships");
            DropIndex("dbo.Matches", new[] { "Championship_Id" });
            RenameColumn(table: "dbo.Matches", name: "Championship_Id", newName: "ChampionshipId");
            AlterColumn("dbo.Matches", "ChampionshipId", c => c.Int(nullable: false));
            CreateIndex("dbo.Matches", "ChampionshipId");
            AddForeignKey("dbo.Matches", "ChampionshipId", "dbo.Championships", "Id", cascadeDelete: true);
            DropColumn("dbo.Matches", "ChampoinshipId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Matches", "ChampoinshipId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Matches", "ChampionshipId", "dbo.Championships");
            DropIndex("dbo.Matches", new[] { "ChampionshipId" });
            AlterColumn("dbo.Matches", "ChampionshipId", c => c.Int());
            RenameColumn(table: "dbo.Matches", name: "ChampionshipId", newName: "Championship_Id");
            CreateIndex("dbo.Matches", "Championship_Id");
            AddForeignKey("dbo.Matches", "Championship_Id", "dbo.Championships", "Id");
        }
    }
}
