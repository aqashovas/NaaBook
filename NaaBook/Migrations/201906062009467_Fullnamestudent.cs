namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Fullnamestudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Fullname", c => c.String());
            DropColumn("dbo.Students", "Name");
            DropColumn("dbo.Students", "Surname");
            DropColumn("dbo.Students", "Fathername");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Fathername", c => c.String());
            AddColumn("dbo.Students", "Surname", c => c.String());
            AddColumn("dbo.Students", "Name", c => c.String());
            DropColumn("dbo.Students", "Fullname");
        }
    }
}
