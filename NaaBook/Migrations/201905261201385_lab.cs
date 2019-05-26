namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class lab : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Laboratories", "GroupId", "dbo.Groups");
            DropIndex("dbo.Laboratories", new[] { "GroupId" });
            AddColumn("dbo.Laboratories", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Laboratories", "StudentId");
            AddForeignKey("dbo.Laboratories", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            DropColumn("dbo.Laboratories", "GroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Laboratories", "GroupId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Laboratories", "StudentId", "dbo.Students");
            DropIndex("dbo.Laboratories", new[] { "StudentId" });
            DropColumn("dbo.Laboratories", "StudentId");
            CreateIndex("dbo.Laboratories", "GroupId");
            AddForeignKey("dbo.Laboratories", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
    }
}
