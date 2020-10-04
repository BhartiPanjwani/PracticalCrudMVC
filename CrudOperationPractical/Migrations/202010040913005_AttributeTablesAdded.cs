namespace CrudOperationPractical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttributeTablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.AttributeValues",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AttributeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Attributes", t => t.AttributeId, cascadeDelete: true)
                .Index(t => t.AttributeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AttributeValues", "AttributeId", "dbo.Attributes");
            DropForeignKey("dbo.Attributes", "CategoryId", "dbo.Categories");
            DropIndex("dbo.AttributeValues", new[] { "AttributeId" });
            DropIndex("dbo.Attributes", new[] { "CategoryId" });
            DropTable("dbo.AttributeValues");
            DropTable("dbo.Attributes");
        }
    }
}
