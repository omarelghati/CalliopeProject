namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addelementstogroupeNiveau : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into GroupeEnseignants Values(1,3)");
            Sql("Insert into GroupeEnseignants Values(2,3)");
        }
        
        public override void Down()
        {
        }
    }
}
