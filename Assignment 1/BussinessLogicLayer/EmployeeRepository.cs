using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccessLayer;

namespace Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeDAO _employeeDAO;

        public EmployeeRepository()
        {
            _employeeDAO = new EmployeeDAO();
        }

        public void AddEmployee(Employee employee)
        {
            _employeeDAO.AddEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _employeeDAO.DeleteEmployee(id);
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeDAO.GetEmployeeById(id);
        }

        public List<Employee> GetEmployees()
        {
            return _employeeDAO.GetEmployees();
        }

        public void UpdateEmployee(Employee employee)
        {
            _employeeDAO.UpdateEmployee(employee);
        }

        public Employee Login(string userName, string password)
        {
            return _employeeDAO.Login(userName, password);
        }

    }
}
