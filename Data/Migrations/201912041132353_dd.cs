namespace Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.decision", "scoreFinal", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.decision", "scoreFinal");
        }
    }
}
