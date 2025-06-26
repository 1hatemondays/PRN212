using System;
using System.Collections.Generic;
using BusinessObjects;

namespace Repositories
{
    public interface IOrderDetailRepository
    {
        List<OrderDetail> GetOrderDetails();
        OrderDetail GetOrderDetailById(int id);
        void AddOrderDetail(OrderDetail orderDetail);
        void UpdateOrderDetail(OrderDetail orderDetail);
        void DeleteOrderDetail(int id);
        List<OrderDetail> SearchOrderDetails(string searchTerm);
    }
}
