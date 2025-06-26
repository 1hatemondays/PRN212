using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace Services
{
    public interface IOrderService
    {
        List<Order> GetOrders();
        Order GetOrderById(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
        List<Order> SearchOrder(string searchTerm);
        List<Order> GetOrderByPeriod(DateTime startDate, DateTime endDate);
    }
}