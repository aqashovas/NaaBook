namespace NaaBook.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dbsetsetting : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Headerimg = c.String(),
                        Mail = c.String(),
                        Address = c.String(),
                        Facebook = c.String(),
                        Twitter = c.String(),
                        Instagram = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
        }
    }
}
