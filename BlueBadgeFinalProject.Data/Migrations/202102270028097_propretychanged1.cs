namespace BlueBadgeFinalProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class propretychanged1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review", "hotelid", c => c.Int(nullable: false));
            AlterColumn("dbo.Review", "Rating", c => c.Double(nullable: false));
            CreateIndex("dbo.Review", "hotelid");
            AddForeignKey("dbo.Review", "hotelid", "dbo.Hotel", "HotelId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review", "hotelid", "dbo.Hotel");
            DropIndex("dbo.Review", new[] { "hotelid" });
            AlterColumn("dbo.Review", "Rating", c => c.String(nullable: false));
            DropColumn("dbo.Review", "hotelid");
        }
    }
}
