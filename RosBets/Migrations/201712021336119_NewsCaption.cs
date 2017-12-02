namespace RosBets.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewsCaption : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.News", "Caption", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.News", "Caption");
        }
    }
}
