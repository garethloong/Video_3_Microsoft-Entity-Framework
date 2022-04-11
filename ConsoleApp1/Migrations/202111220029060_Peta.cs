namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Peta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nastavniks", "Titula", c => c.String());
            DropColumn("dbo.Nastavniks", "Zvanje");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Nastavniks", "Zvanje", c => c.String());
            DropColumn("dbo.Nastavniks", "Titula");
        }
    }
}
