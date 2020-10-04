namespace CrudOperationPractical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductTableAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                        AttributeId = c.Int(nullable: false),
                        AttributeValuesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attributes", t => t.AttributeId, cascadeDelete: false)
                .ForeignKey("dbo.AttributeValues", t => t.AttributeValuesId, cascadeDelete: false)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: false)
                .Index(t => t.CategoryId)
                .Index(t => t.AttributeId)
                .Index(t => t.AttributeValuesId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "AttributeValuesId", "dbo.AttributeValues");
            DropForeignKey("dbo.Products", "AttributeId", "dbo.Attributes");
            DropIndex("dbo.Products", new[] { "AttributeValuesId" });
            DropIndex("dbo.Products", new[] { "AttributeId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Products");
        }
    }
}
