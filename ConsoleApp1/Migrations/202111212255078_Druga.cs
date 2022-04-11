namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Druga : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UpisGodines", "StudentId", "dbo.Students");
            DropPrimaryKey("dbo.Students");
            CreateTable(
                "dbo.Korisniks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Nastavniks",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Zvanje = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Referents",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Korisniks", t => t.Id)
                .Index(t => t.Id);
            
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Students", "Id");
            CreateIndex("dbo.Students", "Id");
            AddForeignKey("dbo.Students", "Id", "dbo.Korisniks", "Id");
            AddForeignKey("dbo.UpisGodines", "StudentId", "dbo.Students", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UpisGodines", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Students", "Id", "dbo.Korisniks");
            DropForeignKey("dbo.Referents", "Id", "dbo.Korisniks");
            DropForeignKey("dbo.Nastavniks", "Id", "dbo.Korisniks");
            DropIndex("dbo.Referents", new[] { "Id" });
            DropIndex("dbo.Nastavniks", new[] { "Id" });
            DropIndex("dbo.Students", new[] { "Id" });
            DropPrimaryKey("dbo.Students");
            AlterColumn("dbo.Students", "Id", c => c.Int(nullable: false, identity: true));
            DropTable("dbo.Referents");
            DropTable("dbo.Nastavniks");
            DropTable("dbo.Korisniks");
            AddPrimaryKey("dbo.Students", "Id");
            AddForeignKey("dbo.UpisGodines", "StudentId", "dbo.Students", "Id");
        }
    }
}
