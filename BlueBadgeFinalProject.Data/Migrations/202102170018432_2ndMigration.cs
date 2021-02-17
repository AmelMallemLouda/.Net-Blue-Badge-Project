namespace BlueBadgeFinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2ndMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transaction", "Price", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transaction", "Price");
        }
    }
}
