namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enseignantdiscipline : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nomDiscipline = c.String(nullable: false, maxLength: 255),
                        EvaluationCollective_Id = c.Int(),
                        Enseignant_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvaluationCollectives", t => t.EvaluationCollective_Id)
                .ForeignKey("dbo.Users", t => t.Enseignant_Id)
                .Index(t => t.EvaluationCollective_Id)
                .Index(t => t.Enseignant_Id);
            
            CreateTable(
                "dbo.EvaluationCollectives",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        titre = c.String(nullable: false, maxLength: 255),
                        domaine = c.String(maxLength: 255),
                        date = c.DateTime(nullable: false),
                        Groupe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groupes", t => t.Groupe_Id)
                .Index(t => t.Groupe_Id);
            
            CreateTable(
                "dbo.Competances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nomCompetance = c.String(nullable: false, maxLength: 255),
                        EvaluationCollective_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvaluationCollectives", t => t.EvaluationCollective_Id)
                .Index(t => t.EvaluationCollective_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Disciplines", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.EvaluationCollectives", "Groupe_Id", "dbo.Groupes");
            DropForeignKey("dbo.Disciplines", "EvaluationCollective_Id", "dbo.EvaluationCollectives");
            DropForeignKey("dbo.Competances", "EvaluationCollective_Id", "dbo.EvaluationCollectives");
            DropIndex("dbo.Competances", new[] { "EvaluationCollective_Id" });
            DropIndex("dbo.EvaluationCollectives", new[] { "Groupe_Id" });
            DropIndex("dbo.Disciplines", new[] { "Enseignant_Id" });
            DropIndex("dbo.Disciplines", new[] { "EvaluationCollective_Id" });
            DropTable("dbo.Competances");
            DropTable("dbo.EvaluationCollectives");
            DropTable("dbo.Disciplines");
        }
    }
}
