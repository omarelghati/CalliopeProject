namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rectificationlength : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "type", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "type", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
