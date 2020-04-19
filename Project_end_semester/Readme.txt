Mở file Web.config
Tìm thẻ
<connectionStrings>
    <add name="DefaultConnection" connectionString="Data Source=DESKTOP-EFN18GS;Initial Catalog=MotelDb;Integrated Security=True"
      providerName="System.Data.SqlClient" />
</connectionStrings>
Đổi tên Data Source thành tên laptop

Mở Package Manager Console trong visual studio 
Chọn tools -> NuGet Package Manager -> Package Manager Console
gõ lệnh Update-Database

Hệ thống sẽ tự động tạo CSDL với data


