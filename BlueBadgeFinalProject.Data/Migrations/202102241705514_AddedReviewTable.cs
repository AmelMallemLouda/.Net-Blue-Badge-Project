namespace BlueBadgeFinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedReviewTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Review", "HotelId", "dbo.Hotel");
            DropIndex("dbo.Review", new[] { "HotelId" });
            DropColumn("dbo.Review", "HotelId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review", "HotelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Review", "HotelId");
            AddForeignKey("dbo.Review", "HotelId", "dbo.Hotel", "HotelId", cascadeDelete: true);
        }
    }
}
