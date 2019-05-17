namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lessonroutine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lessonmaterials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.String(),
                        Theme = c.String(),
                        GroupId = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.GroupId)
                .Index(t => t.TeacherId);
            
            CreateTable(
                "dbo.Evaluationtables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeacherId = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        MarkOrAttendanceFirst = c.String(),
                        MarkOrAttendanceSecond = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.StudentId);
            
            AlterColumn("dbo.Timetables", "Day", c => c.String());
            AlterColumn("dbo.Timetables", "Time", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Lessonmaterials", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Evaluationtables", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Evaluationtables", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Lessonmaterials", "GroupId", "dbo.Groups");
            DropIndex("dbo.Evaluationtables", new[] { "StudentId" });
            DropIndex("dbo.Evaluationtables", new[] { "TeacherId" });
            DropIndex("dbo.Lessonmaterials", new[] { "TeacherId" });
            DropIndex("dbo.Lessonmaterials", new[] { "GroupId" });
            AlterColumn("dbo.Timetables", "Time", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Timetables", "Day", c => c.DateTime(nullable: false));
            DropTable("dbo.Evaluationtables");
            DropTable("dbo.Lessonmaterials");
        }
    }
}
