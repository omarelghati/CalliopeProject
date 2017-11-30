namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class phonerestrict : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "phone", c => c.String(nullable: false, maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "phone", c => c.String(nullable: false, maxLength: 12));
        }
    }
}
