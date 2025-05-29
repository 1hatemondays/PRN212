using System.Text;
using OOP2;

Console.OutputEncoding = System.Text.Encoding.UTF8;

FulltimeEmployee fulltimeEmployee = new FulltimeEmployee()
{
    Id = 1,
    IdCard = "123",
    Name = "Dang Mon",
    Birthday = new DateTime(1960, 11, 25)
};
Console.WriteLine("--Thong tin cua con me may--");
Console.WriteLine($"Id={fulltimeEmployee.Id}");
Console.WriteLine("IdCard= " + fulltimeEmployee.IdCard);
Console.WriteLine("Name= " + fulltimeEmployee.Name);
Console.WriteLine("Birthday= " + fulltimeEmployee.Birthday.ToString("dd/MM/yyyy"));
Console.WriteLine("Muc luong: " + fulltimeEmployee.calSalary());


PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
{
    Id = 2,
    IdCard = "123",
    Name = "cu Bill",
    Birthday = new DateTime(2005, 2, 14)
};

partTimeEmployee.WorkingHours = 3;
Console.WriteLine("--Thong tin cua con me may--");
Console.WriteLine($"Id={partTimeEmployee.Id}");
Console.WriteLine("IdCard= " + partTimeEmployee.IdCard);
Console.WriteLine("Name= " + partTimeEmployee.Name);
Console.WriteLine("Birthday= " + partTimeEmployee.Birthday.ToString("dd/MM/yyyy"));
Console.WriteLine("Muc luong: " + partTimeEmployee.calSalary());

Console.WriteLine("--------------USE   TOSTRING()-------------");
Console.WriteLine(fulltimeEmployee);
Console.WriteLine(partTimeEmployee);
