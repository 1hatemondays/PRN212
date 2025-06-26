using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class OrderDAO
    {
        private static List<Order> orders = new List<Order>
        {
            new Order { OrderID = 1, CustomerID = 1, EmployeeID = 1, OrderDate = new DateTime(2023, 10, 1)},
            new Order { OrderID = 2, CustomerID = 2, EmployeeID = 2, OrderDate = new DateTime(2023, 10, 2)},
            new Order { OrderID = 3, CustomerID = 3, EmployeeID = 3, OrderDate = new DateTime(2023, 10, 3)},
            new Order { OrderID = 4, CustomerID = 4, EmployeeID = 4, OrderDate = new DateTime(2023, 10, 4)},
            new Order { OrderID = 5, CustomerID = 5, EmployeeID = 5, OrderDate = new DateTime(2023, 10, 5)}
        };
        public static List<Order> GetOrders() => new List<Order>(orders);
        public static Order GetOrderById(int id) =>
            orders.FirstOrDefault(o => o.OrderID == id);
        public static void AddOrder(Order order) =>
            orders.Add(order);
        public static void UpdateOrder(Order order)
        {
            var existing = orders.FirstOrDefault(o => o.OrderID == order.OrderID);
            if (existing != null)
            {
                existing.CustomerID = order.CustomerID;
                existing.EmployeeID = order.EmployeeID;
                existing.OrderDate = order.OrderDate;
            }
        }
        public static void DeleteOrder(int id)
        {
            var toRemove = orders.FirstOrDefault(o => o.OrderID == id);
            if (toRemove != null)
            {
                orders.Remove(toRemove);
            }
        }
        public static List<Order> SearchOrder(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<Order>(orders);
            return orders
                .Where(o => o.CustomerID.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            o.EmployeeID.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                            o.OrderDate.ToString("d").Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
        public static List<Order> GetOrderByPeriod(DateTime startDate, DateTime endDate)
        {
            // Lấy phần ngày (loại bỏ phần thời gian) của startDate
            DateTime startOfDay = startDate.Date;
            // Lấy phần ngày của endDate và cộng thêm 1 ngày để bao trọn cả ngày cuối cùng
            DateTime endOfDay = endDate.Date.AddDays(1);

            return orders
                // Sửa lại điều kiện Where như sau:
                .Where(o => o.OrderDate >= startOfDay && o.OrderDate < endOfDay)
                .OrderByDescending(o => o.OrderDate)
                .ToList();
        }
    }
}