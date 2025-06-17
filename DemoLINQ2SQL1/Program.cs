using System.Text;
using DemoLINQ2SQL1;

Console.OutputEncoding = Encoding.UTF8;
string connectionString = @"server = MARIA\SQLEXPRESS;database=MyStore;uid=sa;pwd=12345;";
MyStoreDataContext context = new MyStoreDataContext(connectionString);
//Câu 1: Truy vấn toàn bộ danh mục
var dsdm = context.Categories.ToList();
Console.WriteLine("Câu 1: Truy vấn toàn bộ danh mục");
dsdm.ForEach (x =>
        Console.WriteLine(x.CategoryID + "\t" + x.CategoryName)) ;
//Câu 2: Dùng querry syntax để lọc ra toàn bộ sản phẩm
var dsp = from p in context.Products
           select p;
Console.WriteLine("\nCâu 2: Dùng querry syntax để lọc ra toàn bộ sản phẩm");
foreach (var p in dsp)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}
//Câu 3: Tìm danh mục khi biết mã danh mục
int dmd = 3;
Category cat = context.Categories.FirstOrDefault(x => x.CategoryID == dmd);
if(cat != null)
{
    Console.WriteLine("\nDanh mục có mã {0} là {1}", dmd, cat.CategoryName);
}
else
{
    Console.WriteLine("\nKhông tìm thấy danh mục có mã {0}", dmd);
}
//Câu 4: Lọc ra top 3 sản phẩm có giá cao nhất
var top3 = context.Products
    .OrderByDescending(p => p.UnitPrice)
    .Take(3)
    .ToList();
Console.WriteLine("\nCâu 4: Lọc ra top 3 sản phẩm có giá cao nhất");
foreach (var p in top3)
{
    Console.WriteLine(p.ProductID + "\t" + p.ProductName + "\t" + p.UnitPrice);
}
//Câu 5: Thêm mới một danh mục
//Category c1 = new Category();
//c1.CategoryName = "Thực phẩm chức năng";
//context.Categories.InsertOnSubmit(c1);
//context.SubmitChanges();

//Câu 6: Sửa tên danh mục
//Bước 1: Tìm danh mục cần sửa
//Bước 2: Tìm thấy thì sửa
Category c13 = context.Categories.FirstOrDefault(x => x.CategoryID == 13);
if (c13 != null)
{
    c13.CategoryName = "Thực phẩm chức năng và dinh dưỡng";
    context.SubmitChanges();
    Console.WriteLine("\nĐã sửa tên danh mục có mã 13 thành: {0}", c13.CategoryName);
}
else
{
    Console.WriteLine("\nKhông tìm thấy danh mục có mã 13");
}
//Câu 7: Xoá danh mục khi biết mã danh mục
Category c5 = context.Categories.FirstOrDefault(x => x.CategoryID == 5);
if (c5 != null)
{
    context.Categories.DeleteOnSubmit(c5);
    context.SubmitChanges();
    Console.WriteLine("\nĐã xoá danh mục có mã 5");
}
else
{
    Console.WriteLine("\nKhông tìm thấy danh mục có mã 5");
}
//Câu 8: Xóa tất cả danh mục chưa có sản phẩm nào
var emptyCategories = context.Categories
    .Where(c => c.Products.Count == 0)
    .ToList();
context.Categories.DeleteAllOnSubmit(emptyCategories);
context.SubmitChanges();

//Câu 9: Thêm nhiều danh mục cùng 1 lúc
List<Category> newCategories = new List<Category>();
newCategories.Add(new Category { CategoryName = "Đồ gia dụng" });
newCategories.Add(new Category { CategoryName = "Đồ điện tử" });
newCategories.Add(new Category { CategoryName = "Đồ thể thao" });
context.Categories.InsertAllOnSubmit(newCategories);
context.SubmitChanges();