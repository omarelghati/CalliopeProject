namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addRemainingTables : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EvaluationCollectives", "Enseignant_Id", c => c.Int());
            CreateIndex("dbo.EvaluationCollectives", "Enseignant_Id");
            AddForeignKey("dbo.EvaluationCollectives", "Enseignant_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EvaluationCollectives", "Enseignant_Id", "dbo.Users");
            DropIndex("dbo.EvaluationCollectives", new[] { "Enseignant_Id" });
            DropColumn("dbo.EvaluationCollectives", "Enseignant_Id");
        }
    }
}
