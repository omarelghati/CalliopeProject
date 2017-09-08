namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updating : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.NiveauEnseignants", newName: "EnseignantNiveaux");
            DropPrimaryKey("dbo.EnseignantNiveaux");
            AddPrimaryKey("dbo.EnseignantNiveaux", new[] { "Enseignant_Id", "Niveau_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.EnseignantNiveaux");
            AddPrimaryKey("dbo.EnseignantNiveaux", new[] { "Niveau_Id", "Enseignant_Id" });
            RenameTable(name: "dbo.EnseignantNiveaux", newName: "NiveauEnseignants");
        }
    }
}
