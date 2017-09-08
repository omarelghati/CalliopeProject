namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class emploi1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Emplois",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        FileName = c.String(),
                        FilePath = c.String(),
                        Saison_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groupes", t => t.Id)
                .ForeignKey("dbo.Saisons", t => t.Saison_Id, cascadeDelete: true)
                .Index(t => t.Id)
                .Index(t => t.Saison_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Emplois", "Saison_Id", "dbo.Saisons");
            DropForeignKey("dbo.Emplois", "Id", "dbo.Groupes");
            DropIndex("dbo.Emplois", new[] { "Saison_Id" });
            DropIndex("dbo.Emplois", new[] { "Id" });
            DropTable("dbo.Emplois");
        }
    }
}
