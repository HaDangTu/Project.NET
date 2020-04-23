namespace MotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateRoomIdOfInvoiceAndPowerInfo : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0013' WHERE [id] = 'IEW20000001'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0001' WHERE [id] = 'IEW20000002'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0011' WHERE [id] = 'IEW20000003'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0022' WHERE [id] = 'IEW20000004'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0024' WHERE [id] = 'IEW20000005'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0004' WHERE [id] = 'IEW20000006'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0014' WHERE [id] = 'IEW20000007'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0015' WHERE [id] = 'IEW20000008'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0003' WHERE [id] = 'IEW20000009'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0005' WHERE [id] = 'IEW20000010'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0016' WHERE [id] = 'IEW20000011'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0021' WHERE [id] = 'IEW20000012'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0012' WHERE [id] = 'IEW20000013'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0013' WHERE [id] = 'IEW20000014'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0001' WHERE [id] = 'IEW20000015'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0011' WHERE [id] = 'IEW20000016'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0022' WHERE [id] = 'IEW20000017'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0024' WHERE [id] = 'IEW20000018'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0004' WHERE [id] = 'IEW20000019'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0014' WHERE [id] = 'IEW20000020'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0015' WHERE [id] = 'IEW20000021'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0003' WHERE [id] = 'IEW20000022'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0005' WHERE [id] = 'IEW20000023'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0016' WHERE [id] = 'IEW20000024'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0021' WHERE [id] = 'IEW20000025'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0012' WHERE [id] = 'IEW20000026'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0013' WHERE [id] = 'IEW20000027'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0001' WHERE [id] = 'IEW20000028'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0011' WHERE [id] = 'IEW20000029'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0022' WHERE [id] = 'IEW20000030'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0024' WHERE [id] = 'IEW20000031'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0004' WHERE [id] = 'IEW20000032'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0014' WHERE [id] = 'IEW20000033'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0015' WHERE [id] = 'IEW20000034'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0003' WHERE [id] = 'IEW20000035'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0005' WHERE [id] = 'IEW20000036'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0016' WHERE [id] = 'IEW20000037'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0021' WHERE [id] = 'IEW20000038'");
            Sql("UPDATE [dbo].[ElectricityAndWaterInfos] SET [room_id] = 'R0012' WHERE [id] = 'IEW20000039'");


            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0013' WHERE [id] =  'I2000000001'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0013' WHERE [id] =  'I2000000002'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0001' WHERE [id] =  'I2000000003'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0001' WHERE [id] =  'I2000000004'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0011' WHERE [id] =  'I2000000005'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0011' WHERE [id] =  'I2000000006'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0022' WHERE [id] =  'I2000000007'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0022' WHERE [id] =  'I2000000008'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0024' WHERE [id] =  'I2000000009'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0024' WHERE [id] =  'I2000000010'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0004' WHERE [id] =  'I2000000011'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0004' WHERE [id] =  'I2000000012'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0014' WHERE [id] =  'I2000000013'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0014' WHERE [id] =  'I2000000014'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0015' WHERE [id] =  'I2000000015'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0015' WHERE [id] =  'I2000000016'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0003' WHERE [id] =  'I2000000017'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0003' WHERE [id] =  'I2000000018'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0005' WHERE [id] =  'I2000000019'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0005' WHERE [id] =  'I2000000020'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0016' WHERE [id] =  'I2000000021'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0016' WHERE [id] =  'I2000000022'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0021' WHERE [id] =  'I2000000023'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0021' WHERE [id] =  'I2000000024'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0012' WHERE [id] =  'I2000000025'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0012', [proceeds] = 2400000 WHERE [id] =  'I2000000026'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0013' WHERE [id] =  'I2000000027'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0013' WHERE [id] =  'I2000000028'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0001' WHERE [id] =  'I2000000029'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0001' WHERE [id] =  'I2000000030'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0011' WHERE [id] =  'I2000000031'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0011' WHERE [id] =  'I2000000032'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0022' WHERE [id] =  'I2000000033'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0022' WHERE [id] =  'I2000000034'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0024' WHERE [id] =  'I2000000035'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0024' WHERE [id] =  'I2000000036'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0004' WHERE [id] =  'I2000000037'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0004' WHERE [id] =  'I2000000038'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0014' WHERE [id] =  'I2000000039'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0014' WHERE [id] =  'I2000000040'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0015' WHERE [id] =  'I2000000041'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0015' WHERE [id] =  'I2000000042'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0003' WHERE [id] =  'I2000000043'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0003' WHERE [id] =  'I2000000044'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0005' WHERE [id] =  'I2000000045'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0005' WHERE [id] =  'I2000000046'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0016' WHERE [id] =  'I2000000047'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0016' WHERE [id] =  'I2000000048'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0021' WHERE [id] =  'I2000000049'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0021' WHERE [id] =  'I2000000050'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0012' WHERE [id] =  'I2000000051'");
            Sql("Update [dbo].[Invoices] SET [room_id] = 'R0012', [proceeds] = 2400000 WHERE [id] =  'I2000000052'");
        }

        public override void Down()
        {
        }
    }
}
