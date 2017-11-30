namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
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
                    type = c.String(nullable: false, maxLength: 20),
                    Discriminator = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Competances",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    nomCompetance = c.String(nullable: false, maxLength: 255),
                    EvaluationCollective_Id = c.Int(),
                    Discipline_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvaluationCollectives", t => t.EvaluationCollective_Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id)
                .Index(t => t.EvaluationCollective_Id)
                .Index(t => t.Discipline_Id);

            CreateTable(
                "dbo.EvaluationCollectives",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    titre = c.String(nullable: false, maxLength: 255),
                    domaine = c.String(maxLength: 255),
                    date = c.DateTime(nullable: false),
                    Enseignant_Id = c.Int(),
                    Discipline_Id = c.Int(),
                    Niveau_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Enseignant_Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id)
                .ForeignKey("dbo.Niveaux", t => t.Niveau_Id)
                .Index(t => t.Enseignant_Id)
                .Index(t => t.Discipline_Id)
                .Index(t => t.Niveau_Id);

            CreateTable(
                "dbo.Disciplines",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    nomDiscipline = c.String(nullable: false, maxLength: 255),
                    Niveau_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Niveaux", t => t.Niveau_Id)
                .Index(t => t.Niveau_Id);

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

            CreateTable(
                "dbo.Groupes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    nomGroupe = c.String(nullable: false, maxLength: 255),
                    Niveau_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Niveaux", t => t.Niveau_Id)
                .Index(t => t.Niveau_Id);

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
                "dbo.Notes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    note = c.Int(nullable: false),
                    Eleve_Id = c.Int(),
                    SavoirFaire_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Eleves", t => t.Eleve_Id)
                .ForeignKey("dbo.SavoirFaires", t => t.SavoirFaire_Id, cascadeDelete: true)
                .Index(t => t.Eleve_Id)
                .Index(t => t.SavoirFaire_Id);

            CreateTable(
                "dbo.SavoirFaires",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    nomSavoir = c.String(nullable: false, maxLength: 255),
                    Competance_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Competances", t => t.Competance_Id)
                .Index(t => t.Competance_Id);

            CreateTable(
                "dbo.Etats",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    etat = c.Byte(nullable: false),
                    Periode_Id = c.Int(),
                    SavoireFaire_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Periodes", t => t.Periode_Id)
                .ForeignKey("dbo.SavoirFaires", t => t.SavoireFaire_Id)
                .Index(t => t.Periode_Id)
                .Index(t => t.SavoireFaire_Id);

            CreateTable(
                "dbo.Periodes",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    start = c.DateTime(nullable: false),
                    end = c.DateTime(nullable: false),
                    Saison_Id = c.Int(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Saisons", t => t.Saison_Id)
                .Index(t => t.Saison_Id);

            CreateTable(
                "dbo.Saisons",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    dateSaison = c.DateTime(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.EnseignantDisciplines",
                c => new
                {
                    Enseignant_Id = c.Int(nullable: false),
                    Discipline_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Enseignant_Id, t.Discipline_Id })
                .ForeignKey("dbo.Users", t => t.Enseignant_Id, cascadeDelete: true)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .Index(t => t.Enseignant_Id)
                .Index(t => t.Discipline_Id);

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

            CreateTable(
                "dbo.NiveauEnseignants",
                c => new
                {
                    Niveau_Id = c.Int(nullable: false),
                    Enseignant_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Niveau_Id, t.Enseignant_Id })
                .ForeignKey("dbo.Niveaux", t => t.Niveau_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Enseignant_Id, cascadeDelete: true)
                .Index(t => t.Niveau_Id)
                .Index(t => t.Enseignant_Id);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SavoirFaires", "Competance_Id", "dbo.Competances");
            DropForeignKey("dbo.EvaluationCollectives", "Niveau_Id", "dbo.Niveaux");
            DropForeignKey("dbo.EvaluationCollectives", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.EvalutiationIndivs", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.EvalutiationIndivs", "Eleve_Id", "dbo.Eleves");
            DropForeignKey("dbo.Eleves", "Parent_Id", "dbo.Users");
            DropForeignKey("dbo.Notes", "SavoirFaire_Id", "dbo.SavoirFaires");
            DropForeignKey("dbo.Etats", "SavoireFaire_Id", "dbo.SavoirFaires");
            DropForeignKey("dbo.Periodes", "Saison_Id", "dbo.Saisons");
            DropForeignKey("dbo.Etats", "Periode_Id", "dbo.Periodes");
            DropForeignKey("dbo.Notes", "Eleve_Id", "dbo.Eleves");
            DropForeignKey("dbo.Groupes", "Niveau_Id", "dbo.Niveaux");
            DropForeignKey("dbo.NiveauEnseignants", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.NiveauEnseignants", "Niveau_Id", "dbo.Niveaux");
            DropForeignKey("dbo.Disciplines", "Niveau_Id", "dbo.Niveaux");
            DropForeignKey("dbo.GroupeEnseignants", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.GroupeEnseignants", "Groupe_Id", "dbo.Groupes");
            DropForeignKey("dbo.Eleves", "Groupe_Id", "dbo.Groupes");
            DropForeignKey("dbo.EvaluationCollectives", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.EnseignantDisciplines", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.EnseignantDisciplines", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.Competances", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.Competances", "EvaluationCollective_Id", "dbo.EvaluationCollectives");
            DropIndex("dbo.NiveauEnseignants", new[] { "Enseignant_Id" });
            DropIndex("dbo.NiveauEnseignants", new[] { "Niveau_Id" });
            DropIndex("dbo.GroupeEnseignants", new[] { "Enseignant_Id" });
            DropIndex("dbo.GroupeEnseignants", new[] { "Groupe_Id" });
            DropIndex("dbo.EnseignantDisciplines", new[] { "Discipline_Id" });
            DropIndex("dbo.EnseignantDisciplines", new[] { "Enseignant_Id" });
            DropIndex("dbo.Periodes", new[] { "Saison_Id" });
            DropIndex("dbo.Etats", new[] { "SavoireFaire_Id" });
            DropIndex("dbo.Etats", new[] { "Periode_Id" });
            DropIndex("dbo.SavoirFaires", new[] { "Competance_Id" });
            DropIndex("dbo.Notes", new[] { "SavoirFaire_Id" });
            DropIndex("dbo.Notes", new[] { "Eleve_Id" });
            DropIndex("dbo.Groupes", new[] { "Niveau_Id" });
            DropIndex("dbo.Eleves", new[] { "Parent_Id" });
            DropIndex("dbo.Eleves", new[] { "Groupe_Id" });
            DropIndex("dbo.EvalutiationIndivs", new[] { "Enseignant_Id" });
            DropIndex("dbo.EvalutiationIndivs", new[] { "Eleve_Id" });
            DropIndex("dbo.Disciplines", new[] { "Niveau_Id" });
            DropIndex("dbo.EvaluationCollectives", new[] { "Niveau_Id" });
            DropIndex("dbo.EvaluationCollectives", new[] { "Discipline_Id" });
            DropIndex("dbo.EvaluationCollectives", new[] { "Enseignant_Id" });
            DropIndex("dbo.Competances", new[] { "Discipline_Id" });
            DropIndex("dbo.Competances", new[] { "EvaluationCollective_Id" });
            DropTable("dbo.NiveauEnseignants");
            DropTable("dbo.GroupeEnseignants");
            DropTable("dbo.EnseignantDisciplines");
            DropTable("dbo.Saisons");
            DropTable("dbo.Periodes");
            DropTable("dbo.Etats");
            DropTable("dbo.SavoirFaires");
            DropTable("dbo.Notes");
            DropTable("dbo.Niveaux");
            DropTable("dbo.Groupes");
            DropTable("dbo.Eleves");
            DropTable("dbo.EvalutiationIndivs");
            DropTable("dbo.Disciplines");
            DropTable("dbo.EvaluationCollectives");
            DropTable("dbo.Competances");
            DropTable("dbo.Users");
        }
    }
}
