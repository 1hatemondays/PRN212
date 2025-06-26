using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public void AddOrder(Order order)
        {
            OrderDAO.AddOrder(order);
        }
        public void DeleteOrder(int id)
        {
            OrderDAO.DeleteOrder(id);
        }
        public List<Order> GetOrders()
        {
            return OrderDAO.GetOrders();
        }
        public Order GetOrderById(int id)
        {
            return OrderDAO.GetOrderById(id);
        }
        public void UpdateOrder(Order order)
        {
            OrderDAO.UpdateOrder(order);
        }
        public List<Order> GetOrderByPeriod(DateTime startDate, DateTime endDate)
        {
            return OrderDAO.GetOrderByPeriod(startDate, endDate);
        }

        public List<Order> SearchOrder(string searchTerm)
        {
            return OrderDAO.SearchOrder(searchTerm);
        }
    }
}
