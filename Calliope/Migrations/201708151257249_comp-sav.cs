namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class compsav : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SavoirFaires", "Competance_Id", c => c.Int());
            CreateIndex("dbo.SavoirFaires", "Competance_Id");
            AddForeignKey("dbo.SavoirFaires", "Competance_Id", "dbo.Competances", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavoirFaires", "Competance_Id", "dbo.Competances");
            DropIndex("dbo.SavoirFaires", new[] { "Competance_Id" });
            DropColumn("dbo.SavoirFaires", "Competance_Id");
        }
    }
}
