namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedactormediaitem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ActorMediaItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.Binary(),
                        ContentType = c.String(maxLength: 200),
                        Caption = c.String(nullable: false, maxLength: 150),
                        Actor_ActorId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Actors", t => t.Actor_ActorId)
                .Index(t => t.Actor_ActorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ActorMediaItems", "Actor_ActorId", "dbo.Actors");
            DropIndex("dbo.ActorMediaItems", new[] { "Actor_ActorId" });
            DropTable("dbo.ActorMediaItems");
        }
    }
}
