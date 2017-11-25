namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Number : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Matches", "MatchNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Matches", "MatchNumber", c => c.Int(nullable: false));
        }
    }
}
