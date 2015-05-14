namespace ClassifiedApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentifierColumnToImageModel1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Image", "Identifier", c => c.String(maxLength: 450));
            CreateIndex("dbo.Image", "Identifier", unique: true, name: "Identity");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Image", "Identity");
            AlterColumn("dbo.Image", "Identifier", c => c.String());
        }
    }
}
