using BusinessObjects;
using NgoQuangKhoiWPF.Commands;
using Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NgoQuangKhoiWPF.ViewModels
{
    // A wrapper class to display order info cleanly
    public class OrderDisplay
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime OrderDate { get; set; }
        public Order OriginalOrder { get; set; }
    }

    public class OrderViewModel : ViewModelBase
    {
        private readonly IOrderService _ordersService;
        private readonly ICustomerService _customersService;
        private readonly IEmployeeService _employeesService;
        private readonly IOrderDetailService _OrderDetailService;

        private ObservableCollection<OrderDisplay> _orders;
        public ObservableCollection<OrderDisplay> Orders
        {
            get => _orders;
            set => SetProperty(ref _orders, value);
        }

        private OrderDisplay _selectedOrder;
        public OrderDisplay SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                SetProperty(ref _selectedOrder, value);
                LoadOrderDetail(); // Load details when an order is selected
            }
        }

        private ObservableCollection<OrderDetail> _selectedOrderDetail;
        public ObservableCollection<OrderDetail> SelectedOrderDetail
        {
            get => _selectedOrderDetail;
            set => SetProperty(ref _selectedOrderDetail, value);
        }

        // START: Add properties for DatePickers
        private DateTime? _startDate;
        public DateTime? StartDate
        {
            get => _startDate;
            set => SetProperty(ref _startDate, value);
        }

        private DateTime? _endDate;
        public DateTime? EndDate
        {
            get => _endDate;
            set => SetProperty(ref _endDate, value);
        }
        // END: Add properties for DatePickers


        public ICommand LoadOrdersCommand { get; }
        public ICommand FilterOrdersCommand { get; } // Add new command

        public OrderViewModel()
        {
            _ordersService = new OrderService();
            _customersService = new CustomerService(new Repositories.CustomerRepository());
            _employeesService = new EmployeeService();
            _OrderDetailService = new OrderDetailService();
            LoadOrdersCommand = new RelayCommand(LoadOrders);
            FilterOrdersCommand = new RelayCommand(FilterOrders, CanFilter); // Initialize command

            // Set default dates
            EndDate = DateTime.Now;
            StartDate = EndDate.Value.AddMonths(-1);
        }


        private bool CanFilter(object obj)
        {
            // Can only filter if both dates are selected
            return StartDate.HasValue && EndDate.HasValue;
        }

        private void FilterOrders(object obj)
        {
            // Get filtered orders from the service
            var orders = _ordersService.GetOrderByPeriod(StartDate.Value, EndDate.Value);
            // The rest of the logic is the same as LoadOrders
            var customers = _customersService.GetCustomers();
            var employees = _employeesService.GetEmployees();

            var orderDisplayList = from o in orders
                                   join c in customers on o.CustomerID equals c.CustomerID
                                   join e in employees on o.EmployeeID equals e.EmployeeID
                                   select new OrderDisplay
                                   {
                                       OrderID = o.OrderID,
                                       CustomerName = c.ContactName,
                                       EmployeeName = e.Name,
                                       OrderDate = o.OrderDate,
                                       OriginalOrder = o
                                   };
            // The DAO already sorts by descending date
            Orders = new ObservableCollection<OrderDisplay>(orderDisplayList);
        }


        private void LoadOrders(object obj)
        {
            var orders = _ordersService.GetOrders();
            var customers = _customersService.GetCustomers();
            var employees = _employeesService.GetEmployees();

            var orderDisplayList = from o in orders
                                   join c in customers on o.CustomerID equals c.CustomerID
                                   join e in employees on o.EmployeeID equals e.EmployeeID
                                   select new OrderDisplay
                                   {
                                       OrderID = o.OrderID,
                                       CustomerName = c.ContactName,
                                       EmployeeName = e.Name,
                                       OrderDate = o.OrderDate,
                                       OriginalOrder = o
                                   };

            Orders = new ObservableCollection<OrderDisplay>(orderDisplayList);
        }

        private void LoadOrderDetail()
        {
            if (SelectedOrder != null)
            {
                var allDetails = _OrderDetailService.GetOrderDetails();
                var detailsForOrder = allDetails.Where(d => d.OrderID == SelectedOrder.OrderID).ToList();
                SelectedOrderDetail = new ObservableCollection<OrderDetail>(detailsForOrder);
            }
            else
            {
                SelectedOrderDetail = new ObservableCollection<OrderDetail>();
            }
        }
    }
}