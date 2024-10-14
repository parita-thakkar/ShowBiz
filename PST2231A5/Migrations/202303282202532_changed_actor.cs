namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changed_actor : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Actors", "AlternateName", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Actors", "AlternateName", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
