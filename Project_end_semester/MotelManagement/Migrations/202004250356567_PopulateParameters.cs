namespace MotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateParameters : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO [dbo].[Parameters] ([id],[name] ,[type] ,[value] ,[state]) VALUES ('P0001', N'Giá điện', 'INT', '3000', 'True')");
            Sql("INSERT INTO [dbo].[Parameters] ([id],[name] ,[type] ,[value] ,[state]) VALUES ('P0002', N'Giá nước', 'INT', '2000', 'True')");
        }
        
        public override void Down()
        {
            Sql("DELETE FROM [dbo].[Parameters]");
        }
    }
}
