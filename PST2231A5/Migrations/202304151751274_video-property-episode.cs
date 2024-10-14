namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class videopropertyepisode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Episodes", "VideoContentType", c => c.String(maxLength: 200));
            AddColumn("dbo.Episodes", "Video", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Episodes", "Video");
            DropColumn("dbo.Episodes", "VideoContentType");
        }
    }
}
