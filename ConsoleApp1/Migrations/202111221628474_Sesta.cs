namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Sesta : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "OpstinaPrebivalistaId", "dbo.Opstinas");
            DropForeignKey("dbo.Students", "OpstinaRodjenjaId", "dbo.Opstinas");
            DropIndex("dbo.Students", new[] { "OpstinaRodjenjaId" });
            DropIndex("dbo.Students", new[] { "OpstinaPrebivalistaId" });
            DropColumn("dbo.Students", "OpstinaRodjenjaId");
            DropColumn("dbo.Students", "OpstinaPrebivalistaId");
            DropTable("dbo.Opstinas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Opstinas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        Naziv = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Students", "OpstinaPrebivalistaId", c => c.Int());
            AddColumn("dbo.Students", "OpstinaRodjenjaId", c => c.Int());
            CreateIndex("dbo.Students", "OpstinaPrebivalistaId");
            CreateIndex("dbo.Students", "OpstinaRodjenjaId");
            AddForeignKey("dbo.Students", "OpstinaRodjenjaId", "dbo.Opstinas", "Id");
            AddForeignKey("dbo.Students", "OpstinaPrebivalistaId", "dbo.Opstinas", "Id");
        }
    }
}
