namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teachercontact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Mail", c => c.String());
            AddColumn("dbo.Teachers", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Phone");
            DropColumn("dbo.Teachers", "Mail");
        }
    }
}
