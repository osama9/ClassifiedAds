namespace ClassifiedApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImageModelAndAssociatedWithClassifiedAdModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Image",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Path = c.String(),
                        ClassifiedAd_ClassifiedAdId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClassifiedAd", t => t.ClassifiedAd_ClassifiedAdId)
                .Index(t => t.ClassifiedAd_ClassifiedAdId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Image", "ClassifiedAd_ClassifiedAdId", "dbo.ClassifiedAd");
            DropIndex("dbo.Image", new[] { "ClassifiedAd_ClassifiedAdId" });
            DropTable("dbo.Image");
        }
    }
}
