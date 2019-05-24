namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Freeworks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Laboratories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lessonsections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        LessonTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.SubjectId);
            
            AddColumn("dbo.Timetables", "Weeklysection", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Freeworks", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Lessonsections", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Lessonsections", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Laboratories", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Laboratories", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Freeworks", "GroupId", "dbo.Groups");
            DropIndex("dbo.Lessonsections", new[] { "SubjectId" });
            DropIndex("dbo.Lessonsections", new[] { "GroupId" });
            DropIndex("dbo.Laboratories", new[] { "SubjectId" });
            DropIndex("dbo.Laboratories", new[] { "GroupId" });
            DropIndex("dbo.Freeworks", new[] { "SubjectId" });
            DropIndex("dbo.Freeworks", new[] { "GroupId" });
            DropColumn("dbo.Timetables", "Weeklysection");
            DropTable("dbo.Lessonsections");
            DropTable("dbo.Laboratories");
            DropTable("dbo.Freeworks");
        }
    }
}
