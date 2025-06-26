using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace DataAccessLayer
{
    public class OrderDetailDAO
    {
        private static List<OrderDetail> orderDetails = new List<OrderDetail>
        {
            new OrderDetail { OrderID = 1, ProductID = 1, UnitPrice = 18.00m, Quantity = 2, Discount = 0.0f },
            new OrderDetail { OrderID = 1, ProductID = 2, UnitPrice = 19.00m, Quantity = 1, Discount = 0.0f },
            new OrderDetail { OrderID = 2, ProductID = 3, UnitPrice = 10.00m, Quantity = 5, Discount = 0.1f },
            new OrderDetail { OrderID = 3, ProductID = 4, UnitPrice = 22.00m, Quantity = 3, Discount = 0.0f },
            new OrderDetail { OrderID = 4, ProductID = 5, UnitPrice = 21.35m, Quantity = 1, Discount = 0.2f }
        };
        public static List<OrderDetail> GetOrderDetails() => new List<OrderDetail>(orderDetails);
        public static OrderDetail GetOrderDetailById(int orderId) =>
            orderDetails.FirstOrDefault(od => od.OrderID == orderId);
        public static void AddOrderDetail(OrderDetail orderDetail) =>
            orderDetails.Add(orderDetail);
        public static void UpdateOrderDetail(OrderDetail orderDetail)
        {
            var existing = orderDetails.FirstOrDefault(od => od.OrderID == orderDetail.OrderID && od.ProductID == orderDetail.ProductID);
            if (existing != null)
            {
                existing.UnitPrice = orderDetail.UnitPrice;
                existing.Quantity = orderDetail.Quantity;
                existing.Discount = orderDetail.Discount;
            }
        }
        public static void DeleteOrderDetail(int orderId)
        {
            var toRemove = orderDetails.FirstOrDefault(od => od.OrderID == orderId);
            if (toRemove != null)
            {
                orderDetails.Remove(toRemove);
            }
        }
        public static List<OrderDetail> SearchOrderDetails(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
                return new List<OrderDetail>(orderDetails);
            return orderDetails
                .Where(od => od.OrderID.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             od.ProductID.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             od.Quantity.ToString().Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             od.UnitPrice.ToString("F2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             od.Discount.ToString("F2").Contains(searchTerm, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
