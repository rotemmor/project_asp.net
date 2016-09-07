namespace proj1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RecommendationHotel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecommendationHotel", "RecommendationHotel_ID", "dbo.RecommendationHotel");
            DropIndex("dbo.RecommendationHotel", new[] { "RecommendationHotel_ID" });
            DropColumn("dbo.RecommendationHotel", "RecommendationHotel_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RecommendationHotel", "RecommendationHotel_ID", c => c.Int());
            CreateIndex("dbo.RecommendationHotel", "RecommendationHotel_ID");
            AddForeignKey("dbo.RecommendationHotel", "RecommendationHotel_ID", "dbo.RecommendationHotel", "ID");
        }
    }
}
