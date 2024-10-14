namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editedactor : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.ActorMediaItems", new[] { "Actor_ActorId" });
            AlterColumn("dbo.ActorMediaItems", "Actor_ActorId", c => c.Int(nullable: false));
            CreateIndex("dbo.ActorMediaItems", "Actor_ActorId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.ActorMediaItems", new[] { "Actor_ActorId" });
            AlterColumn("dbo.ActorMediaItems", "Actor_ActorId", c => c.Int());
            CreateIndex("dbo.ActorMediaItems", "Actor_ActorId");
        }
    }
}
