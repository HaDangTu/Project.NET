namespace MotelManagement.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateData : DbMigration
    {
        public override void Up()
        {
            //Table Gender
            Sql("INSERT INTO [dbo].[Genders] ([id] ,[name]) VALUES ('G01' , N'Nam')");
            Sql("INSERT INTO [dbo].[Genders] ([id] ,[name]) VALUES ('G02' , N'Nữ')");
            Sql("INSERT INTO [dbo].[Genders] ([id] ,[name]) VALUES ('G03' , N'Khác')");

            //Table State
            Sql("INSERT INTO [dbo].[States] ([id] ,[name]) VALUES ('S01' , N'Đang ở')");
            Sql("INSERT INTO [dbo].[States] ([id] ,[name]) VALUES ('S02' , N'Đã chuyển đi')");

            //Room TypeTable
            Sql("INSERT INTO [dbo].[RoomTypes] ([id] ,[name] ,[number_of_guest] ,[price]) VALUES ('T01' , N'Phòng 2 người' , 2 , 1200000)");
            Sql("INSERT INTO [dbo].[RoomTypes] ([id] ,[name] ,[number_of_guest] ,[price]) VALUES ('T02' , N'Phòng 4 người' , 4 , 2400000)");
            Sql("INSERT INTO [dbo].[RoomTypes] ([id] ,[name] ,[number_of_guest] ,[price]) VALUES ('T03' , N'Phòng 6 người' , 6 , 4800000)");

            //Room table
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0001' ,N'Phòng 101' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0002' ,N'Phòng 102' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0003' ,N'Phòng 103' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0004' ,N'Phòng 104' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0005' ,N'Phòng 105' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0006' ,N'Phòng 106' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0007' ,N'Phòng 107' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0008' ,N'Phòng 108' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0009' ,N'Phòng 109' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0010' ,N'Phòng 110' , 'T01')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0011' ,N'Phòng 201' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0012' ,N'Phòng 202' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0013' ,N'Phòng 203' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0014' ,N'Phòng 204' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0015' ,N'Phòng 205' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0016' ,N'Phòng 206' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0017' ,N'Phòng 207' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0018' ,N'Phòng 208' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0019' ,N'Phòng 209' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0020' ,N'Phòng 210' , 'T02')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0021' ,N'Phòng 301' , 'T03')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0022' ,N'Phòng 302' , 'T03')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0023' ,N'Phòng 303' , 'T03')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0024' ,N'Phòng 304' , 'T03')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0025' ,N'Phòng 305' , 'T03')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0026' ,N'Phòng 306' , 'T03')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0027' ,N'Phòng 307' , 'T03')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0028' ,N'Phòng 308' , 'T03')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0029' ,N'Phòng 309' , 'T03')");
            Sql("INSERT INTO [dbo].[Rooms] ([id], [name], [room_type_id]) VALUES ('R0030' ,N'Phòng 310' , 'T03')");

            //Guest
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000001', N'Nguyễn Văn An', '1996-10-10 00:00:00', 'G01', '272748234', N'Vĩnh Phúc', N'Công nhân', 'R0013', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000002', N'Hồ Thị Trang', '1996-10-20 00:00:00', 'G02', '272748235', N'Vĩnh Phúc', N'Công nhân', 'R0013', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000003', N'Nguyễn Văn Bình', '2010-02-03 00:00:00', 'G01', '272748236', N'Vĩnh Phúc', N'Học sinh', 'R0013', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000004', N'Nguyễn Văn Chí', '2012-05-08 00:00:00', 'G01', '272748237', N'Vĩnh Phúc', N'Học sinh', 'R0013', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000005', N'Nguyễn Cẩm Tú', '2000-05-20 00:00:00', 'G02', '272748238', N'Bình Phước', N'Sinh viên', 'R0001', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000006', N'Hồ Thị Huyền', '2000-04-16 00:00:00', 'G02', '272748239', N'Bình Phước', N'Sinh viên', 'R0001', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000007', N'Trần Thu Trang', '1994-10-10 00:00:00', 'G02', '272748240', N'Đăk Lăk', N'Công nhân', 'R0011', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000008', N'Nguyễn Hoàng Tài', '1995-04-10 00:00:00', 'G01', '272748241', N'Đăk Lăk', N'Công nhân', 'R0011', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000009', N'Nguyễn Hoàng Mĩ Linh', '2010-10-10 00:00:00', 'G02', '272748242', N'Đăk Lăk', N'Học sinh', 'R0011', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000010', N'Nguyễn Thu Huyền', '2012-08-04 00:00:00', 'G02', '272748243', N'Đăk Lăk', N'Học sinh', 'R0011', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000011', N'Trần Văn Hoàng', '1999-08-04 00:00:00', 'G01', '272748244', N'Bình Dương', N'Sinh viên', 'R0022', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000012', N'Nguyễn Quang Huy', '1999-08-05 00:00:00', 'G01', '272748245', N'Bình Dương', N'Sinh viên', 'R0022', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000013', N'Huỳnh Bất Nhân', '1999-08-06 00:00:00', 'G01', '272748246', N'Bình Dương', N'Sinh viên', 'R0022', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000014', N'Nguyễn Chí Tài', '1999-08-07 00:00:00', 'G01', '272748247', N'Bình Dương', N'Sinh viên', 'R0022', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000015', N'Cao Văn Long', '1999-08-08 00:00:00', 'G01', '272748248', N'Bình Dương', N'Sinh viên', 'R0022', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000016', N'Đỗ Hoàng Nguyên', '1999-08-09 00:00:00', 'G01', '272748249', N'Bình Dương', N'Sinh viên', 'R0022', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000017', N'Nguyễn Thị Cẩm Vân', '2000-10-11 00:00:00', 'G02', '272748250', N'Đồng Nai', N'Sinh viên', 'R0024', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000018', N'Ngô Trúc Thủy', '2000-01-23 00:00:00', 'G02', '272748251', N'Đồng Nai', N'Sinh viên', 'R0024', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000019', N'Hồ Thị Mĩ Phượng', '2000-03-04 00:00:00', 'G02', '272748252', N'Đồng Nai', N'Sinh viên', 'R0024', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000020', N'Nguyễn Thị Nga', '2000-12-01 00:00:00', 'G02', '272748253', N'Đồng Nai', N'Sinh viên', 'R0024', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000021', N'Đỗ Thu Trang', '2000-08-02 00:00:00', 'G02', '272748254', N'Đồng Nai', N'Sinh viên', 'R0024', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000022', N'Đỗ Văn Quốc', '1995-02-03 00:00:00', 'G01', '272748255', N'Cà Mau', N'Nhân viên', 'R0004', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000023', N'Nguyễn Đình Toàn', '1995-01-20 00:00:00', 'G01', '272748256', N'Quảng Nam', N'Nhân viên', 'R0014', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000024', N'Trần Huyền My', '1995-02-02 00:00:00', 'G02', '272748257', N'Quảng Nam', N'Công nhân', 'R0014', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000025', N'Nguyễn Đình Tâm', '2019-10-20 00:00:00', 'G01', '272748258', N'Quảng Nam', N'Học sinh', 'R0014', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000026', N'Hoàng Thu Thảo', '2000-10-10 00:00:00', 'G02', '272748259', N'Long An', N'Sinh viên', 'R0015', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000027', N'Đinh Thị Thùy An', '2000-01-03 00:00:00', 'G02', '272748260', N'Long An', N'Sinh viên', 'R0015', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000028', N'Nguyễn Thúy Kiều', '2000-09-02 00:00:00', 'G02', '272748261', N'Long An', N'Sinh viên', 'R0015', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000029', N'Nguyễn Thanh Tâm', '2000-09-23 00:00:00', 'G02', '272748262', N'Long An', N'Sinh viên', 'R0015', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000030', N'Nguyễn Minh Hiếu', '1998-10-10 00:00:00', 'G01', '272748263', N'Bình Thuận', N'Nhân viên', 'R0003', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000031', N'Trương Thị Nga', '1995-03-03 00:00:00', 'G02', '272748264', N'Quảng Nam', N'Nhân viên', 'R0005', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000032', N'Nguyễn Hoàng Trâm', '1995-09-20 00:00:00', 'G02', '272748265', N'Quảng Nam', N'Nhân viên', 'R0005', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000033', N'Trần Trung Trực', '1998-11-10 00:00:00', 'G01', '272748266', N'Gia Lai', N'Sinh viên', 'R0016', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000034', N'Trần Nam Khang', '1998-09-11 00:00:00', 'G01', '272748267', N'Gia Lai', N'Sinh viên', 'R0016', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000035', N'Nguyễn Minh Nhật', '1998-10-12 00:00:00', 'G01', '272748268', N'Gia Lai', N'Sinh viên', 'R0016', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000036', N'Đỗ Hoàng Khang', '1998-11-13 00:00:00', 'G01', '272748269', N'Gia Lai', N'Sinh viên', 'R0016', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000037', N'Lê Thu Trang', '1999-01-10 00:00:00', 'G02', '272748270', N'Nha Trang', N'Sinh viên', 'R0021', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000038', N'Nguyễn Mị Nương', '1999-08-11 00:00:00', 'G02', '272748271', N'Nha Trang', N'Sinh viên', 'R0021', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000039', N'Đỗ Minh Trang', '1999-10-12 00:00:00', 'G02', '272748272', N'Nha Trang', N'Sinh viên', 'R0021', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000040', N'Trần Thị Thu Huyền', '1999-11-13 00:00:00', 'G02', '272748273', N'Nha Trang', N'Sinh viên', 'R0021', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000041', N'Ngô Thị Trúc', '1999-12-14 00:00:00', 'G02', '272748274', N'Nha Trang', N'Sinh viên', 'R0021', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000042', N'Nguyễn Thị Thanh Thủy', '1999-07-15 00:00:00', 'G02', '272748275', N'Nha Trang', N'Sinh viên', 'R0021', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000043', N'Trần Hoàng Trung', '1995-09-20 00:00:00', 'G01', '272748276', N'Cà Mau', N'Công nhân', 'R0012', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000044', N'Nguyễn Văn Thanh', '1995-10-21 00:00:00', 'G01', '272748277', N'Cà Mau', N'Công nhân', 'R0012', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000045', N'Đoàn Văn Đức', '1995-01-22 00:00:00', 'G01', '272748278', N'Cà Mau', N'Công nhân', 'R0012', 'S01')");
            Sql("INSERT INTO [dbo].[Guests] ([id] ,[name] ,[birthday] ,[gender_id] ,[identity_card_number] ,[home_town] ,[occupation] ,[room_id] ,[state_id]) VALUES ('G000046', N'Nguyễn Phước Hoàng', '1995-02-23 00:00:00', 'G01', '272748279', N'Cà Mau', N'Công nhân', 'R0012', 'S01')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Guests");
            Sql("DELETE FROM Rooms");
            Sql("DELETE FROM RooomTypes");
            Sql("DELETE FROM States");
            Sql("DELETE FROM Genders");
        }
    }
}
