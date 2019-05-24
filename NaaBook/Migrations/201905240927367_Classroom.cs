namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Classroom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Timetables", "Classroom", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Timetables", "Classroom");
        }
    }
}
