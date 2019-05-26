namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class freework : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Freeworks", "GroupId", "dbo.Groups");
            DropIndex("dbo.Freeworks", new[] { "GroupId" });
            AddColumn("dbo.Freeworks", "StudentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Freeworks", "StudentId");
            AddForeignKey("dbo.Freeworks", "StudentId", "dbo.Students", "Id", cascadeDelete: true);
            DropColumn("dbo.Freeworks", "GroupId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Freeworks", "GroupId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Freeworks", "StudentId", "dbo.Students");
            DropIndex("dbo.Freeworks", new[] { "StudentId" });
            DropColumn("dbo.Freeworks", "StudentId");
            CreateIndex("dbo.Freeworks", "GroupId");
            AddForeignKey("dbo.Freeworks", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
    }
}
