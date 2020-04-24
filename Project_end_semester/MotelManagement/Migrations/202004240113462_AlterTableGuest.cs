namespace MotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AlterTableGuest : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Guests", "start_date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Guests", "start_date");
        }
    }
}
