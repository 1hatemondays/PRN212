using System.Text;

Console.OutputEncoding = Encoding.UTF8;
int[]arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

//Câu 1: Lọc ra các số chẵn
//C1: Dùng extension method - method syntax
var ar_chan = arr.Where(x => x % 2 == 0);
Console.WriteLine("Cac so chan - method syntax:");
ar_chan.ToList().ForEach(x => Console.WriteLine(x));
//C2: Dùng query syntax
var ar_chan2 = from x in arr
               where x % 2 == 0
               select x;
Console.WriteLine("Cac so chan - query syntax:");
ar_chan2.ToList().ForEach(x => Console.WriteLine(x));

//Câu 2: Tăng các phần tử lẻ lên 2 đơn vị   
var arr2 = arr.Where(x => x % 2 != 0)
               .Select(x => x + 2);
Console.WriteLine("Cac so le tang 2 don vi:");
arr2.ToList().ForEach(x => Console.WriteLine(x));

//Câu 3: Sắp xếp các phần tử tăng dần
var arr3 = arr.OrderBy(x => x);
var arr4 = from x in arr
           orderby x ascending
           select x;
Console.WriteLine("Cac so sap xep tang dan:");
foreach (var item in arr4)
{
    Console.Write(item + " ");
}

//Câu 4: Sắp xếp các phần tử giảm dần
var arr5 = arr.OrderByDescending(x => x);
var arr6 = from x in arr
           orderby x descending
           select x;
Console.WriteLine("\nCac so sap xep giam dan:");
foreach (var item in arr6)
{
    Console.Write(item + " ");
}

//Câu 5: Đếm các phần lẻ
Console.WriteLine("So luong so le: " + arr.Where(x => x % 2 != 0).Count());
int dem_so_le = (from x in arr
                 where x % 2 != 0
                 select x).Count();
Console.WriteLine("So luong so le - query syntax: " + dem_so_le);