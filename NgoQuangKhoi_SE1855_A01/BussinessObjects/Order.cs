using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjects
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public int EmployeeID { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public decimal OrderTotal => OrderDetails?.Sum(od => od.Quantity * od.UnitPrice) ?? 0;


    }
}
