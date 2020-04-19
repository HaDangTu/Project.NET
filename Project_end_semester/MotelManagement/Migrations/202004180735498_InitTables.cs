namespace MotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genders",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false, maxLength: 255),
                        birthday = c.String(nullable: false),
                        gender_id = c.String(nullable: false, maxLength: 128),
                        identity_card_number = c.String(maxLength: 10),
                        home_town = c.String(nullable: false, maxLength: 50),
                        occupation = c.String(nullable: false, maxLength: 50),
                        room_id = c.String(nullable: false, maxLength: 128),
                        state_id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Genders", t => t.gender_id, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.room_id, cascadeDelete: true)
                .ForeignKey("dbo.States", t => t.state_id, cascadeDelete: true)
                .Index(t => t.gender_id)
                .Index(t => t.room_id)
                .Index(t => t.state_id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                        room_type_id = c.String(nullable: false, maxLength: 128),
                        user_id = c.String(nullable: true, maxLength: 128),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RoomTypes", t => t.room_type_id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.user_id, cascadeDelete: true)
                .Index(t => t.room_type_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                        number_of_guest = c.Int(nullable: false),
                        price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.States",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ElectricityAndWaterInfos",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        room_id = c.String(nullable: false, maxLength: 128),
                        date = c.DateTime(nullable: false),
                        electric_indicator = c.Long(nullable: false),
                        water_indicator = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Rooms", t => t.room_id, cascadeDelete: true)
                .Index(t => t.room_id);
            
            CreateTable(
                "dbo.Invoices",
                c => new
                    {
                        id = c.String(nullable: false, maxLength: 128),
                        room_id = c.String(nullable: false, maxLength: 128),
                        from_date = c.DateTime(nullable: false),
                        to_date = c.DateTime(nullable: false),
                        collection_date = c.DateTime(nullable: false),
                        content = c.String(nullable: false, maxLength: 255),
                        debt = c.Double(nullable: false),
                        proceeds = c.Double(nullable: false),
                        excess_cash = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Rooms", t => t.room_id, cascadeDelete: true)
                .Index(t => t.room_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoices", "room_id", "dbo.Rooms");
            DropForeignKey("dbo.ElectricityAndWaterInfos", "room_id", "dbo.Rooms");
            DropForeignKey("dbo.Guests", "state_id", "dbo.States");
            DropForeignKey("dbo.Guests", "room_id", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "user_id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Rooms", "room_type_id", "dbo.RoomTypes");
            DropForeignKey("dbo.Guests", "gender_id", "dbo.Genders");
            DropIndex("dbo.Invoices", new[] { "room_id" });
            DropIndex("dbo.ElectricityAndWaterInfos", new[] { "room_id" });
            DropIndex("dbo.Rooms", new[] { "user_id" });
            DropIndex("dbo.Rooms", new[] { "room_type_id" });
            DropIndex("dbo.Guests", new[] { "state_id" });
            DropIndex("dbo.Guests", new[] { "room_id" });
            DropIndex("dbo.Guests", new[] { "gender_id" });
            DropTable("dbo.Invoices");
            DropTable("dbo.ElectricityAndWaterInfos");
            DropTable("dbo.States");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Guests");
            DropTable("dbo.Genders");
        }
    }
}
