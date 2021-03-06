﻿namespace CrudOperationPractical.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ValidationMigration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Attributes", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Categories", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.AttributeValues", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Name", c => c.String());
            AlterColumn("dbo.AttributeValues", "Name", c => c.String());
            AlterColumn("dbo.Categories", "Name", c => c.String());
            AlterColumn("dbo.Attributes", "Name", c => c.String());
        }
    }
}
