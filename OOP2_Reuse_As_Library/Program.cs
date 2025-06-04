using System.Text;
using OOP2;
using OOP2_Reuse_As_Library;
Console.OutputEncoding =  System.Text.Encoding.UTF8;

FulltimeEmployee el = new FulltimeEmployee();
el.Id = 1;
el.Name = "Mon";
el.IdCard = "123";
el.Birthday = new DateTime(1990, 12, 25);

Console.WriteLine("----Thong tin cua con me may----");
Console.WriteLine(el);
Console.WriteLine("===>AGE" +el.TinhTuoi());
