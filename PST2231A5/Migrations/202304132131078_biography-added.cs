namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class biographyadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "Biography", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Actors", "Biography");
        }
    }
}
