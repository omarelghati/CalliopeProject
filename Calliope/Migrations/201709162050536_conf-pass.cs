namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confpass : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "password", c => c.String(nullable: false, maxLength: 255));
        }
    }
}
