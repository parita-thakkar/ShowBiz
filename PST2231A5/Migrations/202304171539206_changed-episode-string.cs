namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedepisodestring : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Episodes", "ShowName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Episodes", "ShowName", c => c.Int(nullable: false));
        }
    }
}
