using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        public void AddOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailDAO.AddOrderDetail(orderDetail);
        }
        public void DeleteOrderDetail(int orderId)
        {
            OrderDetailDAO.DeleteOrderDetail(orderId);
        }
        public List<OrderDetail> GetOrderDetails()
        {
            return OrderDetailDAO.GetOrderDetails();
        }
        public OrderDetail GetOrderDetailById(int orderId)
        {
            return OrderDetailDAO.GetOrderDetailById(orderId);
        }
        public void UpdateOrderDetail(OrderDetail orderDetail)
        {
            OrderDetailDAO.UpdateOrderDetail(orderDetail);
        }
        public List<OrderDetail> SearchOrderDetails(string searchTerm)
        {
            return OrderDetailDAO.SearchOrderDetails(searchTerm);
        }
    }
}
