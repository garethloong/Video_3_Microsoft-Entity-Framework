namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Treca : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "AdresaStanovanja");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "AdresaStanovanja", c => c.String());
        }
    }
}
