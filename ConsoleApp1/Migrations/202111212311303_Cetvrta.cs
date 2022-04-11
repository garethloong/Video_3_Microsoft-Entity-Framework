namespace ConsoleApp1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cetvrta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Korisniks", "Ime", c => c.String());
            AddColumn("dbo.Korisniks", "Prezime", c => c.String());
            AddColumn("dbo.Korisniks", "Username", c => c.String());
            AddColumn("dbo.Korisniks", "Password", c => c.String());
            DropColumn("dbo.Students", "Ime");
            DropColumn("dbo.Students", "Prezime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Prezime", c => c.String());
            AddColumn("dbo.Students", "Ime", c => c.String());
            DropColumn("dbo.Korisniks", "Password");
            DropColumn("dbo.Korisniks", "Username");
            DropColumn("dbo.Korisniks", "Prezime");
            DropColumn("dbo.Korisniks", "Ime");
        }
    }
}
