namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AkademskaGodinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Opis = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Fakultets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Smjers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                        FakultetId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Fakultets", t => t.FakultetId, cascadeDelete: true)
                .Index(t => t.FakultetId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Ime = c.String(),
                        Prezime = c.String(),
                        BrojIndexa = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UpisGodines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        DatumUpisa = c.DateTime(nullable: false),
                        GodinaStudija = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SmjerId = c.Int(nullable: false),
                        AkademskaGodinaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AkademskaGodinas", t => t.AkademskaGodinaId, cascadeDelete: true)
                .ForeignKey("dbo.Smjers", t => t.SmjerId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SmjerId)
                .Index(t => t.AkademskaGodinaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpisGodines", "StudentId", "dbo.Students");
            DropForeignKey("dbo.UpisGodines", "SmjerId", "dbo.Smjers");
            DropForeignKey("dbo.UpisGodines", "AkademskaGodinaId", "dbo.AkademskaGodinas");
            DropForeignKey("dbo.Smjers", "FakultetId", "dbo.Fakultets");
            DropIndex("dbo.UpisGodines", new[] { "AkademskaGodinaId" });
            DropIndex("dbo.UpisGodines", new[] { "SmjerId" });
            DropIndex("dbo.UpisGodines", new[] { "StudentId" });
            DropIndex("dbo.Smjers", new[] { "FakultetId" });
            DropTable("dbo.UpisGodines");
            DropTable("dbo.Students");
            DropTable("dbo.Smjers");
            DropTable("dbo.Fakultets");
            DropTable("dbo.AkademskaGodinas");
        }
    }
}
