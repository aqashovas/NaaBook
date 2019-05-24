namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimetablevsTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Timetables", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Timetables", "SemesterNo", c => c.Int(nullable: false));
            AddColumn("dbo.Teachers", "Fathername", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Fathername");
            DropColumn("dbo.Timetables", "SemesterNo");
            DropColumn("dbo.Timetables", "Status");
        }
    }
}
