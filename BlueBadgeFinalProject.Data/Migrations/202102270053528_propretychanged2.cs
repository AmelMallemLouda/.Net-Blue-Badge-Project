namespace BlueBadgeFinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propretychanged2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Review", new[] { "hotelid" });
            CreateIndex("dbo.Review", "HotelId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Review", new[] { "HotelId" });
            CreateIndex("dbo.Review", "hotelid");
        }
    }
}
