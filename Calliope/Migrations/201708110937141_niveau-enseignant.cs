namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class niveauenseignant : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Niveaux", "Enseignant_Id", c => c.Int());
            CreateIndex("dbo.Niveaux", "Enseignant_Id");
            AddForeignKey("dbo.Niveaux", "Enseignant_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Niveaux", "Enseignant_Id", "dbo.Users");
            DropIndex("dbo.Niveaux", new[] { "Enseignant_Id" });
            DropColumn("dbo.Niveaux", "Enseignant_Id");
        }
    }
}
