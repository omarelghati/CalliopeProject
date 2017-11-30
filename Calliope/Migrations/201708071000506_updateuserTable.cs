namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateuserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "phone", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "phone");
        }
    }
}
