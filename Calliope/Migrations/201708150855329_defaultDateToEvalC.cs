namespace Calliope.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class defaultDateToEvalC : DbMigration
    {
        public override void Up()
        {
            Sql("ALTER TABLE EvaluationCollectives ADD CONSTRAINT ConstraintName DEFAULT GETDATE() FOR date");
        }
        
        public override void Down()
        {
        }
    }
}
