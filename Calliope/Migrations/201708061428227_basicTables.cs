namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class basicTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groupes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nomGroupe = c.String(nullable: false, maxLength: 255),
                        Niveau_Id = c.Int(),
                        Enseignant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Niveaux", t => t.Niveau_Id)
                .ForeignKey("dbo.Users", t => t.Enseignant_Id)
                .Index(t => t.Niveau_Id)
                .Index(t => t.Enseignant_Id);
            
            CreateTable(
                "dbo.Niveaux",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        niveau = c.String(nullable: false, maxLength: 255),
                        cycle = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nomComplet = c.String(nullable: false, maxLength: 255),
                        email = c.String(nullable: false, maxLength: 255),
                        phone = c.String(nullable: false, maxLength: 12),
                        civilite = c.String(nullable: false, maxLength: 20),
                        password = c.String(nullable: false, maxLength: 255),
                        confirmPassword = c.String(nullable: false, maxLength: 255),
                        type = c.String(nullable: false, maxLength: 10),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EvalutiationIndivs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        titre = c.String(nullable: false, maxLength: 255),
                        domaine = c.String(maxLength: 255),
                        date = c.DateTime(nullable: false),
                        Eleve_Id = c.Int(),
                        Enseignant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eleves", t => t.Eleve_Id)
                .ForeignKey("dbo.Users", t => t.Enseignant_Id)
                .Index(t => t.Eleve_Id)
                .Index(t => t.Enseignant_Id);
            
            CreateTable(
                "dbo.Eleves",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nomComplet = c.String(),
                        gender = c.String(),
                        dateDeNaissance = c.DateTime(nullable: false),
                        Groupe_Id = c.Int(),
                        Parent_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groupes", t => t.Groupe_Id)
                .ForeignKey("dbo.Users", t => t.Parent_Id)
                .Index(t => t.Groupe_Id)
                .Index(t => t.Parent_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groupes", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.EvalutiationIndivs", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.EvalutiationIndivs", "Eleve_Id", "dbo.Eleves");
            DropForeignKey("dbo.Eleves", "Parent_Id", "dbo.Users");
            DropForeignKey("dbo.Eleves", "Groupe_Id", "dbo.Groupes");
            DropForeignKey("dbo.Groupes", "Niveau_Id", "dbo.Niveaux");
            DropIndex("dbo.Eleves", new[] { "Parent_Id" });
            DropIndex("dbo.Eleves", new[] { "Groupe_Id" });
            DropIndex("dbo.EvalutiationIndivs", new[] { "Enseignant_Id" });
            DropIndex("dbo.EvalutiationIndivs", new[] { "Eleve_Id" });
            DropIndex("dbo.Groupes", new[] { "Enseignant_Id" });
            DropIndex("dbo.Groupes", new[] { "Niveau_Id" });
            DropTable("dbo.Eleves");
            DropTable("dbo.EvalutiationIndivs");
            DropTable("dbo.Users");
            DropTable("dbo.Niveaux");
            DropTable("dbo.Groupes");
        }
    }
}
