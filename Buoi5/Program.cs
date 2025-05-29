using System.Text;
using OOP3_Extension_Method;
Console.OutputEncoding =  System.Text.Encoding.UTF8;

int n1 = 5;
Console.WriteLine("Tong tu 1 den 5= " + n1.TongTu1DenN());
int n2 = 10;
Console.WriteLine("Tong tu 1 den 10=" + n2.TongTu1DenN());
Console.WriteLine("Tong tu 1 den 100=" +100.TongTu1DenN());

Console.WriteLine("10+20=" + 10.Sum(20));

int[]arr = new int[8];
arr.TaoMang();
Console.WriteLine("Truoc khi sap xep: ");
arr.XuatMang();
Console.WriteLine("Mang sau khi sap xep tang dan: ");
arr.SapXepTangDan();
arr.XuatMang();
Console.WriteLine();