namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedstringid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ActorMediaItems", "StringId", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ActorMediaItems", "StringId");
        }
    }
}
