namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rectifyGroupEnsRElation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Groupes", "Enseignant_Id", "dbo.Users");
            DropIndex("dbo.Groupes", new[] { "Enseignant_Id" });
            CreateTable(
                "dbo.GroupeEnseignants",
                c => new
                    {
                        Groupe_Id = c.Int(nullable: false),
                        Enseignant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Groupe_Id, t.Enseignant_Id })
                .ForeignKey("dbo.Groupes", t => t.Groupe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Enseignant_Id, cascadeDelete: true)
                .Index(t => t.Groupe_Id)
                .Index(t => t.Enseignant_Id);
            
            DropColumn("dbo.Groupes", "Enseignant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Groupes", "Enseignant_Id", c => c.Int());
            DropForeignKey("dbo.GroupeEnseignants", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.GroupeEnseignants", "Groupe_Id", "dbo.Groupes");
            DropIndex("dbo.GroupeEnseignants", new[] { "Enseignant_Id" });
            DropIndex("dbo.GroupeEnseignants", new[] { "Groupe_Id" });
            DropTable("dbo.GroupeEnseignants");
            CreateIndex("dbo.Groupes", "Enseignant_Id");
            AddForeignKey("dbo.Groupes", "Enseignant_Id", "dbo.Users", "Id");
        }
    }
}
