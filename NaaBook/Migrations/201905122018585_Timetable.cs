namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Timetable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Group_Id", "dbo.Groups");
            DropIndex("dbo.Students", new[] { "Group_Id" });
            RenameColumn(table: "dbo.Students", name: "Group_Id", newName: "GroupId");
            CreateTable(
                "dbo.Timetables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                        Time = c.DateTime(nullable: false),
                        TeacherId = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherId, cascadeDelete: true)
                .Index(t => t.TeacherId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        DepartmentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .Index(t => t.DepartmentId);
            
            AddColumn("dbo.Groups", "DepartmenId", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "GroupId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "GroupId");
            AddForeignKey("dbo.Students", "GroupId", "dbo.Groups", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Timetables", "TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Timetables", "GroupId", "dbo.Groups");
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropIndex("dbo.Timetables", new[] { "GroupId" });
            DropIndex("dbo.Timetables", new[] { "TeacherId" });
            DropIndex("dbo.Students", new[] { "GroupId" });
            AlterColumn("dbo.Students", "GroupId", c => c.Int());
            DropColumn("dbo.Groups", "DepartmenId");
            DropTable("dbo.Teachers");
            DropTable("dbo.Timetables");
            RenameColumn(table: "dbo.Students", name: "GroupId", newName: "Group_Id");
            CreateIndex("dbo.Students", "Group_Id");
            AddForeignKey("dbo.Students", "Group_Id", "dbo.Groups", "Id");
        }
    }
}
