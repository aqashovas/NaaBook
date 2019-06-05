namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userTeacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "Username", c => c.String());
            AddColumn("dbo.Teachers", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Teachers", "Password");
            DropColumn("dbo.Teachers", "Username");
        }
    }
}
