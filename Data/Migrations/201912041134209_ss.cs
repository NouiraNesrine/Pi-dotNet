namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ss : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.evaluationsheet", "rate", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.evaluationsheet", "rate");
        }
    }
}
