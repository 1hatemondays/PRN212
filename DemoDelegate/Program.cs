
using System.Text;

class Program
{
    public delegate int MyDelegate1(int x, int y);
    static int Cong(int x, int y)
    {
        return x + y;
    }
    static int Tru(int x, int y)
    {
        return x - y;
    }
    public delegate int[] MyDelegate2(int n);
    static int[] DanhSachSoChan(int n)
    {
        List<int> list = new List<int>();
        for (int i = 0; i <= n; i++)
        {
            if (i % 2 == 0)
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }
    static int[]DanhSachSoNguyenTo(int n)
    {
        List<int> list = new List<int>();
        for (int i = 2; i <= n; i++)
        {
            bool isPrime = true;
            for (int j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }
            if (isPrime)
            {
                list.Add(i);
            }
        }
        return list.ToArray();
    }
    public static void Main(string [] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        MyDelegate1 d1 = new MyDelegate1(Cong);
        Console.WriteLine("Tong cua 5 va 8: " + d1(5, 8));
        d1 = new MyDelegate1(Tru);
        Console.WriteLine("Hieu cua 8 va 5: " + d1(8, 5));
        MyDelegate2 d2 = new MyDelegate2(DanhSachSoChan);
        int[] arr = d2(10);
        Console.WriteLine("Danh sach so chan tu 0 den 10:");
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }

        d2 = new MyDelegate2(DanhSachSoNguyenTo);
        arr = d2(10);
        Console.WriteLine("\nDanh sach so nguyen to tu 0 den 10:");
        foreach (int item in arr)
        {
            Console.Write(item + " ");
        }
    }
}