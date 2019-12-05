namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "pidev.formation", newSchema: "dbo");
            MoveTable(name: "pidev.user", newSchema: "dbo");
            MoveTable(name: "pidev.Quiz", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.Quiz", newSchema: "pidev");
            MoveTable(name: "dbo.user", newSchema: "pidev");
            MoveTable(name: "dbo.formation", newSchema: "pidev");
        }
    }
}
