namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class createNotes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        note = c.Int(nullable: false),
                        EvaluationIndiv_Id = c.Int(),
                        SavoirFaire_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.EvalutiationIndivs", t => t.EvaluationIndiv_Id)
                .ForeignKey("dbo.SavoirFaires", t => t.SavoirFaire_Id)
                .Index(t => t.EvaluationIndiv_Id)
                .Index(t => t.SavoirFaire_Id);
            
            CreateTable(
                "dbo.SavoirFaires",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        nomSavoir = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Notes", "SavoirFaire_Id", "dbo.SavoirFaires");
            DropForeignKey("dbo.Etats", "SavoireFaire_Id", "dbo.SavoirFaires");
            DropForeignKey("dbo.Periodes", "Saison_Id", "dbo.Saisons");
            DropForeignKey("dbo.Etats", "Periode_Id", "dbo.Periodes");
            DropForeignKey("dbo.Notes", "EvaluationIndiv_Id", "dbo.EvalutiationIndivs");
            DropIndex("dbo.Periodes", new[] { "Saison_Id" });
            DropIndex("dbo.Etats", new[] { "SavoireFaire_Id" });
            DropIndex("dbo.Etats", new[] { "Periode_Id" });
            DropIndex("dbo.Notes", new[] { "SavoirFaire_Id" });
            DropIndex("dbo.Notes", new[] { "EvaluationIndiv_Id" });
            DropTable("dbo.Saisons");
            DropTable("dbo.Periodes");
            DropTable("dbo.Etats");
            DropTable("dbo.SavoirFaires");
            DropTable("dbo.Notes");
        }
    }
}
