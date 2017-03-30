namespace Foodie.Backend.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Recipes", "Text");
            DropColumn("dbo.Recipes", "Complete");
            DropColumn("dbo.SecureRecipes", "Text");
            DropColumn("dbo.SecureRecipes", "Complete");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SecureRecipes", "Complete", c => c.Boolean(nullable: false));
            AddColumn("dbo.SecureRecipes", "Text", c => c.String());
            AddColumn("dbo.Recipes", "Complete", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recipes", "Text", c => c.String());
        }
    }
}
