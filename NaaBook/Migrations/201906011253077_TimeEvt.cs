namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TimeEvt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Evaluationtables", "Time", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Evaluationtables", "Time");
        }
    }
}
