namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emploigroup : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Emplois", "Groupe_Id", "dbo.Groupes");
            DropForeignKey("dbo.Emplois", "Saison_Id", "dbo.Saisons");
            DropIndex("dbo.Emplois", new[] { "Groupe_Id" });
            DropIndex("dbo.Emplois", new[] { "Saison_Id" });
            DropTable("dbo.Emplois");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.id);
            
            CreateIndex("dbo.Emplois", "Saison_Id");
            CreateIndex("dbo.Emplois", "Groupe_Id");
            AddForeignKey("dbo.Emplois", "Saison_Id", "dbo.Saisons", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Emplois", "Groupe_Id", "dbo.Groupes", "Id", cascadeDelete: true);
        }
    }
}
