namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class disciplineenseignant : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Disciplines", "Enseignant_Id", "dbo.Users");
            DropIndex("dbo.Disciplines", new[] { "Enseignant_Id" });
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
            
            DropColumn("dbo.Disciplines", "Enseignant_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Disciplines", "Enseignant_Id", c => c.Int());
            DropForeignKey("dbo.EnseignantDisciplines", "Discipline_Id", "dbo.Disciplines");
            DropForeignKey("dbo.EnseignantDisciplines", "Enseignant_Id", "dbo.Users");
            DropIndex("dbo.EnseignantDisciplines", new[] { "Discipline_Id" });
            DropIndex("dbo.EnseignantDisciplines", new[] { "Enseignant_Id" });
            DropTable("dbo.EnseignantDisciplines");
            CreateIndex("dbo.Disciplines", "Enseignant_Id");
            AddForeignKey("dbo.Disciplines", "Enseignant_Id", "dbo.Users", "Id");
        }
    }
}
