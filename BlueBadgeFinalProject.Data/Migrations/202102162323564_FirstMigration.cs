namespace BlueBadgeFinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "CustomerName", c => c.String());
            DropColumn("dbo.Transaction", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transaction", "Price", c => c.Double(nullable: false));
            DropColumn("dbo.Transaction", "CustomerName");
        }
    }
}
