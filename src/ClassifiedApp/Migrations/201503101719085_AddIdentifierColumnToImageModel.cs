namespace ClassifiedApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIdentifierColumnToImageModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Image", "Identifier", c => c.String());

        }
        
        public override void Down()
        {
            DropColumn("dbo.Image", "Identifier");
        }
    }
}
