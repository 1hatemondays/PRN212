using DemoLINQ2Object2;
using System.Text;

Console.OutputEncoding = Encoding.UTF8;

ListProduct listProduct = new ListProduct();
listProduct.AddProduct();
// Câu 1: Lọc ra các sản phẩm có giá từ a tới b
//Sử dụng method syntax và query syntax
var result1 = listProduct.FilteredProducts(100, 200);
Console.WriteLine("Cac san pham co gia tu 100 den 200 - method syntax:");
result1.ForEach(x => Console.WriteLine(x));

// Câu 2: Lọc ra các sản phẩm có giá giảm dần
var result2 = listProduct.SortedProducts();
Console.WriteLine("Cac san pham sap xep giam dan theo gia - method syntax:");
result2.ForEach(x => Console.WriteLine(x));

//Tổng giá trị sản phẩm trong kho
Console.WriteLine("Tong gia tri san pham trong kho: " + listProduct.SumOfValue());