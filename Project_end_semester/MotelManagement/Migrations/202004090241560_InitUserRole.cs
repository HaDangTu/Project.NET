namespace MotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitUserRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES ('RO001', 'Owner')");
            Sql("INSERT INTO AspNetRoles (Id, Name) VALUES ('RO002', 'Guest')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM AspNetRoles");
        }
    }
}
