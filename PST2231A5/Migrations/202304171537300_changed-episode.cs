namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedepisode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Episodes", "ShowName", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Episodes", "ShowName");
        }
    }
}
