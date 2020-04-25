namespace MotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateParameters1 : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM [dbo].[Parameters] ");
        }
        
        public override void Down()
        {
            
        }
    }
}
