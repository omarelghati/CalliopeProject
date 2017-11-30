namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class evalcNiveau : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EvaluationCollectives", "Groupe_Id", "dbo.Groupes");
            DropIndex("dbo.EvaluationCollectives", new[] { "Groupe_Id" });
            AddColumn("dbo.EvaluationCollectives", "Niveau_Id", c => c.Int());
            CreateIndex("dbo.EvaluationCollectives", "Niveau_Id");
            AddForeignKey("dbo.EvaluationCollectives", "Niveau_Id", "dbo.Niveaux", "Id");
            DropColumn("dbo.EvaluationCollectives", "Groupe_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EvaluationCollectives", "Groupe_Id", c => c.Int());
            DropForeignKey("dbo.EvaluationCollectives", "Niveau_Id", "dbo.Niveaux");
            DropIndex("dbo.EvaluationCollectives", new[] { "Niveau_Id" });
            DropColumn("dbo.EvaluationCollectives", "Niveau_Id");
            CreateIndex("dbo.EvaluationCollectives", "Groupe_Id");
            AddForeignKey("dbo.EvaluationCollectives", "Groupe_Id", "dbo.Groupes", "Id");
        }
    }
}
