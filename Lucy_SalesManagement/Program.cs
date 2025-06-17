using Lucy_SalesManagement;
using System.Text;

Console.OutputEncoding = System.Text.Encoding.UTF8;

string connectionString = @"server=MARIA\SQLEXPRESS;database=Lucy_SalesData;uid=sa;pwd=12345;";
Lucy_SalesDataDataContext context = new Lucy_SalesDataDataContext(connectionString);
//Câu 1: Lấy chi tiết thông tin khách hàng khi biết mã
int customerId = 1;
Customer cus = context.Customers.FirstOrDefault(x => x.CustomerID == customerId);
if (cus == null)
{
    Console.WriteLine("Không tìm thấy khách hàng có mã {0}", customerId);
}
else
{
    Console.WriteLine("Thông tin khách hàng có mã {0} là:", customerId);
    Console.WriteLine("ID: {0}, Tên: {1}, Số điện thoại: {2}", cus.CustomerID, cus.ContactName, cus.Phone);

    // Câu 2: Lấy danh sách đơn hàng của khách hàng này
    if (cus != null)
    {
        Console.WriteLine("Danh sách đơn hàng của khách hàng: ");
        foreach (Order order in cus.Orders)
        {
            Console.WriteLine("Mã đơn hàng: {0}, Ngày đặt hàng: {1}",
                order.OrderID, order.OrderDate);
        }
    }
}

//Câu 3: bổ sung thêm 1 cột tổng tiền của hóa đơn
if(cus != null)
{
    Console.WriteLine("Tổng tiền của hóa đơn: ");
    foreach (Order order in cus.Orders)
    {
        // Fix for CS0019: Convert 'Discount' (float) to 'decimal' before performing multiplication  
        decimal totalAmount = order.Order_Details.Sum(od => od.UnitPrice * od.Quantity - (od.UnitPrice * od.Quantity * (decimal)od.Discount));
        Console.WriteLine("Mã đơn hàng: {0}, Ngày đặt hàng: {1}, Tổng tiền: {2}", order.OrderID, order.OrderDate, totalAmount);
    }
}