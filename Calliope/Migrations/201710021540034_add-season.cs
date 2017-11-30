namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addseason : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Absences", "Saison_Id", c => c.Int());
            AddColumn("dbo.Disciplines", "Saison_Id", c => c.Int());
            AddColumn("dbo.EvaluationCollectives", "Saison_Id", c => c.Int());
            AddColumn("dbo.Groupes", "Saison_Id", c => c.Int());
            AddColumn("dbo.Saisons", "SeasonStart", c => c.DateTime(nullable: false));
            AddColumn("dbo.Saisons", "SeasonEnd", c => c.DateTime(nullable: false));
            AddColumn("dbo.Notes", "Saison_Id", c => c.Int());
            CreateIndex("dbo.Absences", "Saison_Id");
            CreateIndex("dbo.Disciplines", "Saison_Id");
            CreateIndex("dbo.EvaluationCollectives", "Saison_Id");
            CreateIndex("dbo.Groupes", "Saison_Id");
            CreateIndex("dbo.Notes", "Saison_Id");
            AddForeignKey("dbo.Notes", "Saison_Id", "dbo.Saisons", "Id");
            AddForeignKey("dbo.Groupes", "Saison_Id", "dbo.Saisons", "Id");
            AddForeignKey("dbo.EvaluationCollectives", "Saison_Id", "dbo.Saisons", "Id");
            AddForeignKey("dbo.Disciplines", "Saison_Id", "dbo.Saisons", "Id");
            AddForeignKey("dbo.Absences", "Saison_Id", "dbo.Saisons", "Id");
            DropColumn("dbo.Saisons", "dateSaison");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Saisons", "dateSaison", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Absences", "Saison_Id", "dbo.Saisons");
            DropForeignKey("dbo.Disciplines", "Saison_Id", "dbo.Saisons");
            DropForeignKey("dbo.EvaluationCollectives", "Saison_Id", "dbo.Saisons");
            DropForeignKey("dbo.Groupes", "Saison_Id", "dbo.Saisons");
            DropForeignKey("dbo.Notes", "Saison_Id", "dbo.Saisons");
            DropIndex("dbo.Notes", new[] { "Saison_Id" });
            DropIndex("dbo.Groupes", new[] { "Saison_Id" });
            DropIndex("dbo.EvaluationCollectives", new[] { "Saison_Id" });
            DropIndex("dbo.Disciplines", new[] { "Saison_Id" });
            DropIndex("dbo.Absences", new[] { "Saison_Id" });
            DropColumn("dbo.Notes", "Saison_Id");
            DropColumn("dbo.Saisons", "SeasonEnd");
            DropColumn("dbo.Saisons", "SeasonStart");
            DropColumn("dbo.Groupes", "Saison_Id");
            DropColumn("dbo.EvaluationCollectives", "Saison_Id");
            DropColumn("dbo.Disciplines", "Saison_Id");
            DropColumn("dbo.Absences", "Saison_Id");
        }
    }
}
