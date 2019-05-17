namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbsetandexams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Colloquiums",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Colloquium1 = c.Int(nullable: false),
                        Colloquium2 = c.Int(nullable: false),
                        Colloquium3 = c.Int(nullable: false),
                        StudentId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                        Teacher_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.SubjectId)
                .Index(t => t.Teacher_Id);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StudentId = c.Int(nullable: false),
                        Examresult = c.Int(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        SubjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.StudentId, cascadeDelete: true)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.StudentId)
                .Index(t => t.TeacherId)
                .Index(t => t.SubjectId);
            
            AddColumn("dbo.Lessonmaterials", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Evaluationtables", "SubjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Timetables", "SubjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Timetables", "SubjectId");
            CreateIndex("dbo.Evaluationtables", "SubjectId");
            CreateIndex("dbo.Lessonmaterials", "SubjectId");
            AddForeignKey("dbo.Evaluationtables", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Lessonmaterials", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Timetables", "SubjectId", "dbo.Subjects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Colloquiums", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Timetables", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Lessonmaterials", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Evaluationtables", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Exams", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Exams", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Colloquiums", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Colloquiums", "Teacher_Id", "dbo.Teachers");
            DropIndex("dbo.Lessonmaterials", new[] { "SubjectId" });
            DropIndex("dbo.Exams", new[] { "SubjectId" });
            DropIndex("dbo.Exams", new[] { "TeacherId" });
            DropIndex("dbo.Exams", new[] { "StudentId" });
            DropIndex("dbo.Evaluationtables", new[] { "SubjectId" });
            DropIndex("dbo.Timetables", new[] { "SubjectId" });
            DropIndex("dbo.Colloquiums", new[] { "Teacher_Id" });
            DropIndex("dbo.Colloquiums", new[] { "SubjectId" });
            DropIndex("dbo.Colloquiums", new[] { "StudentId" });
            DropColumn("dbo.Timetables", "SubjectId");
            DropColumn("dbo.Evaluationtables", "SubjectId");
            DropColumn("dbo.Lessonmaterials", "SubjectId");
            DropTable("dbo.Exams");
            DropTable("dbo.Subjects");
            DropTable("dbo.Colloquiums");
        }
    }
}
