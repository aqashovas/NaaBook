namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adminuser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Admins", "FullName", c => c.String());
            AddColumn("dbo.Admins", "Username", c => c.String());
            DropColumn("dbo.Admins", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Admins", "Name", c => c.String());
            DropColumn("dbo.Admins", "Username");
            DropColumn("dbo.Admins", "FullName");
        }
    }
}
