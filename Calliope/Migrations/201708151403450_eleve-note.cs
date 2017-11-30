namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class elevenote : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notes", "EvaluationIndiv_Id", "dbo.EvalutiationIndivs");
            DropIndex("dbo.Notes", new[] { "EvaluationIndiv_Id" });
            AddColumn("dbo.Notes", "Eleve_Id", c => c.Int());
            CreateIndex("dbo.Notes", "Eleve_Id");
            AddForeignKey("dbo.Notes", "Eleve_Id", "dbo.Eleves", "Id");
            DropColumn("dbo.Notes", "EvaluationIndiv_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notes", "EvaluationIndiv_Id", c => c.Int());
            DropForeignKey("dbo.Notes", "Eleve_Id", "dbo.Eleves");
            DropIndex("dbo.Notes", new[] { "Eleve_Id" });
            DropColumn("dbo.Notes", "Eleve_Id");
            CreateIndex("dbo.Notes", "EvaluationIndiv_Id");
            AddForeignKey("dbo.Notes", "EvaluationIndiv_Id", "dbo.EvalutiationIndivs", "Id");
        }
    }
}
