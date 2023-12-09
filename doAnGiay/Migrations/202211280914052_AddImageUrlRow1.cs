﻿namespace doAnGiay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImageUrlRow1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "ImageUrl");
        }
    }
}
