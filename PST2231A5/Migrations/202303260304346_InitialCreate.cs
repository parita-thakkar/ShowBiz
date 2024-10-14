namespace PST2231A5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actors",
                c => new
                    {
                        ActorId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        AlternateName = c.String(nullable: false, maxLength: 150),
                        BirthDate = c.DateTime(nullable: false),
                        Height = c.Double(nullable: false),
                        ImageUrl = c.String(nullable: false, maxLength: 250),
                        Executive = c.String(nullable: false, maxLength: 250),
                    })
                .PrimaryKey(t => t.ActorId);
            
            CreateTable(
                "dbo.Shows",
                c => new
                    {
                        ShowId = c.Int(nullable: false, identity: true),
                        Coordinator = c.String(nullable: false, maxLength: 250),
                        Genre = c.String(nullable: false, maxLength: 50),
                        ImageUrl = c.String(nullable: false, maxLength: 250),
                        Name = c.String(nullable: false, maxLength: 150),
                        ReleaseDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShowId);
            
            CreateTable(
                "dbo.Episodes",
                c => new
                    {
                        EpisodeId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 150),
                        Genre = c.String(nullable: false, maxLength: 160),
                        AirDate = c.DateTime(nullable: false),
                        Clerk = c.String(),
                        EpisodeNumber = c.Int(nullable: false),
                        ImageUrl = c.String(nullable: false, maxLength: 250),
                        SeasonNumber = c.Int(nullable: false),
                        ShowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EpisodeId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.GenreId);
            
            CreateTable(
                "dbo.RoleClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ShowActors",
                c => new
                    {
                        Show_ShowId = c.Int(nullable: false),
                        Actor_ActorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Show_ShowId, t.Actor_ActorId })
                .ForeignKey("dbo.Shows", t => t.Show_ShowId, cascadeDelete: true)
                .ForeignKey("dbo.Actors", t => t.Actor_ActorId, cascadeDelete: true)
                .Index(t => t.Show_ShowId)
                .Index(t => t.Actor_ActorId);
            
            CreateTable(
                "dbo.EpisodeShows",
                c => new
                    {
                        Episode_EpisodeId = c.Int(nullable: false),
                        Show_ShowId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Episode_EpisodeId, t.Show_ShowId })
                .ForeignKey("dbo.Episodes", t => t.Episode_EpisodeId, cascadeDelete: true)
                .ForeignKey("dbo.Shows", t => t.Show_ShowId, cascadeDelete: true)
                .Index(t => t.Episode_EpisodeId)
                .Index(t => t.Show_ShowId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.EpisodeShows", "Show_ShowId", "dbo.Shows");
            DropForeignKey("dbo.EpisodeShows", "Episode_EpisodeId", "dbo.Episodes");
            DropForeignKey("dbo.ShowActors", "Actor_ActorId", "dbo.Actors");
            DropForeignKey("dbo.ShowActors", "Show_ShowId", "dbo.Shows");
            DropIndex("dbo.EpisodeShows", new[] { "Show_ShowId" });
            DropIndex("dbo.EpisodeShows", new[] { "Episode_EpisodeId" });
            DropIndex("dbo.ShowActors", new[] { "Actor_ActorId" });
            DropIndex("dbo.ShowActors", new[] { "Show_ShowId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.EpisodeShows");
            DropTable("dbo.ShowActors");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.RoleClaims");
            DropTable("dbo.Genres");
            DropTable("dbo.Episodes");
            DropTable("dbo.Shows");
            DropTable("dbo.Actors");
        }
    }
}
