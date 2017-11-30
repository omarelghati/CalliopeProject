namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class evalCdiscipline : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Competances", "EvaluationCollective_Id", "dbo.EvaluationCollectives");
            DropForeignKey("dbo.Disciplines", "EvaluationCollective_Id", "dbo.EvaluationCollectives");
            DropForeignKey("dbo.EvaluationCollectives", "Groupe_Id", "dbo.Groupes");
            DropIndex("dbo.Disciplines", new[] { "EvaluationCollective_Id" });
            DropIndex("dbo.EvaluationCollectives", new[] { "Groupe_Id" });
            DropIndex("dbo.Competances", new[] { "EvaluationCollective_Id" });
            DropColumn("dbo.Disciplines", "EvaluationCollective_Id");
            DropTable("dbo.EvaluationCollectives");
            DropTable("dbo.Competances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Competances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nomCompetance = c.String(nullable: false, maxLength: 255),
                        EvaluationCollective_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Disciplines", "EvaluationCollective_Id", c => c.Int());
            CreateIndex("dbo.Competances", "EvaluationCollective_Id");
            CreateIndex("dbo.EvaluationCollectives", "Groupe_Id");
            CreateIndex("dbo.Disciplines", "EvaluationCollective_Id");
            AddForeignKey("dbo.EvaluationCollectives", "Groupe_Id", "dbo.Groupes", "Id");
            AddForeignKey("dbo.Disciplines", "EvaluationCollective_Id", "dbo.EvaluationCollectives", "Id");
            AddForeignKey("dbo.Competances", "EvaluationCollective_Id", "dbo.EvaluationCollectives", "Id");
        }
    }
}
