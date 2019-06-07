namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settingphone : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Settings", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "Phone");
        }
    }
}
