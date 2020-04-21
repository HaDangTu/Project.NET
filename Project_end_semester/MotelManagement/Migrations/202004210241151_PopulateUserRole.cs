namespace MotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateUserRole : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id] ,[Name]) VALUES ('R001' , 'Owner')");
            Sql("INSERT INTO [dbo].[AspNetRoles] ([Id] ,[Name]) VALUES ('R002' , 'Guest')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [dbo].[AspNetRoles]");
        }
    }
}
