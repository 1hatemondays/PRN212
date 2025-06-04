using System.Text;
using DemoAliasAndClone;

Console.OutputEncoding = Encoding.UTF8;

Student s1 = new Student();
s1.Id = 1;
s1.Name = "Nguyễn Văn A";

Student s2 = new Student();
s2.Id = 2;
s2.Name = "Nguyễn Văn B";

s1 = s2; // s1 và s2 trỏ đến cùng một đối tượng - alias
s2.Name = "Nguyễn Văn C"; // Thay đổi tên của s2 cũng sẽ thay đổi tên của s1
Console.WriteLine(s1.Name);

Product p1 = new Product()
{
    Id = 1,
    Name = "P1",
    Quantity = 10,
    Price = 20
};

Product p2 = new Product()
{
    Id = 2,
    Name = "P2",
    Price = 20,
    Quantity = 15
};

p1 = p2;

p2.Name = "Dais";
p2.Price = 80;
Console.WriteLine(p1);

Product p3 = new Product()
{
    Id = 3,
    Name = "p3",
    Quantity = 30,
    Price = 50
};

Product p4 = new Product()
{
    Id = 4,
    Name = "P4",
    Quantity = 40,
    Price = 90
};

Product p5 = p3;
p3 = p4;

Product p6 = p4.clone();
//sao chép toàn bộ dữ liệu trong ô nhớ mà p4 đang quản lí
//sang ô nhớ mới và cho p6 quản lí
//lúc này không phải là alias vì p4 và p6 quản lí 2 ô nhớ khác nhau
Console.WriteLine("Du lieu cua p6: ");
Console.WriteLine(p6);
Console.WriteLine("Du lieu cua p4");
Console.WriteLine(p4);
p4.Name = "Thuoc";
Console.WriteLine("Du lieu cua p6:");
Console.WriteLine(p6);
Console.WriteLine("Du lieu cua p4");
Console.WriteLine(p4);