# Các công thức chú ý
- Nếu cuộc gọi quốc tế 00, 17100, 17700, 17800, 17900 nếu chưa có trong danh sách thì được tính giá mặc định là:
Block 6s: 320 - Block 1s: 53


# Các lệnh với database
Add-Migration Initial -OutputDir "Data/Migrations" -Contex AppDbContext
Update-Database -Contex AppDbContext

Scaffold-DbContext "Data Source=database.vntt.com.vn;Initial Catalog=VNTT_Billing_v2;Persist Security Info=True;User ID=namhh1;Password=namhh@vntt" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity/Billing -Force -Context BillingDbContext
Update Tracking Model class
Scaffold-DbContext "Data Source=180.148.1.178,1577;Initial Catalog=VNTT_CUOCDT;Persist Security Info=True;User ID=namhh;Password=namhh@vntt" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Entity/CuocDT -Force -Context CUOCDTDbContext



Scaffold-DbContext "Data Source=database.vntt.com.vn;Initial Catalog=CustomerDB;Persist Security Info=True;User ID=namhh1;Password=namhh@vntt" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data/Models/Customer -Force -Context CustomerContext