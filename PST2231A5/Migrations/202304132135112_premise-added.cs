namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class premiseadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Shows", "Premise", c => c.String(maxLength: 250));
            AddColumn("dbo.Episodes", "Premise", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Episodes", "Premise");
            DropColumn("dbo.Shows", "Premise");
        }
    }
}
