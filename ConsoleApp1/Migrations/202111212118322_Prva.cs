namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prva : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Students", "OpstinaRodjenjaId", c => c.Int());
            AddColumn("dbo.Students", "OpstinaPrebivalistaId", c => c.Int());
            CreateIndex("dbo.Students", "OpstinaRodjenjaId");
            CreateIndex("dbo.Students", "OpstinaPrebivalistaId");
            AddForeignKey("dbo.Students", "OpstinaPrebivalistaId", "dbo.Opstinas", "Id");
            AddForeignKey("dbo.Students", "OpstinaRodjenjaId", "dbo.Opstinas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "OpstinaRodjenjaId", "dbo.Opstinas");
            DropForeignKey("dbo.Students", "OpstinaPrebivalistaId", "dbo.Opstinas");
            DropIndex("dbo.Students", new[] { "OpstinaPrebivalistaId" });
            DropIndex("dbo.Students", new[] { "OpstinaRodjenjaId" });
            DropColumn("dbo.Students", "OpstinaPrebivalistaId");
            DropColumn("dbo.Students", "OpstinaRodjenjaId");
            DropTable("dbo.Opstinas");
        }
    }
}
