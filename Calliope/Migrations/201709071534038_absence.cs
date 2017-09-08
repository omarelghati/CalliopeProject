namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class absence : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Absences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Discipline_Id = c.Int(nullable: false),
                        Eleve_Id = c.Int(nullable: false),
                        Enseignant_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Disciplines", t => t.Discipline_Id, cascadeDelete: true)
                .ForeignKey("dbo.Eleves", t => t.Eleve_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.Enseignant_Id, cascadeDelete: true)
                .Index(t => t.Discipline_Id)
                .Index(t => t.Eleve_Id)
                .Index(t => t.Enseignant_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Absences", "Enseignant_Id", "dbo.Users");
            DropForeignKey("dbo.Absences", "Eleve_Id", "dbo.Eleves");
            DropForeignKey("dbo.Absences", "Discipline_Id", "dbo.Disciplines");
            DropIndex("dbo.Absences", new[] { "Enseignant_Id" });
            DropIndex("dbo.Absences", new[] { "Eleve_Id" });
            DropIndex("dbo.Absences", new[] { "Discipline_Id" });
            DropTable("dbo.Absences");
        }
    }
}
