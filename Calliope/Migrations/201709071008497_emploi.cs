namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emploi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emplois",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FilePath = c.String(),
                        Groupe_Id = c.Int(nullable: false),
                        Saison_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Groupes", t => t.Groupe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Saisons", t => t.Saison_Id, cascadeDelete: true)
                .Index(t => t.Groupe_Id)
                .Index(t => t.Saison_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emplois", "Saison_Id", "dbo.Saisons");
            DropForeignKey("dbo.Emplois", "Groupe_Id", "dbo.Groupes");
            DropIndex("dbo.Emplois", new[] { "Saison_Id" });
            DropIndex("dbo.Emplois", new[] { "Groupe_Id" });
            DropTable("dbo.Emplois");
        }
    }
}
