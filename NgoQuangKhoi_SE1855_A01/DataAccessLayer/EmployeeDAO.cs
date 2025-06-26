using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;

// The namespace should be DataAccess, not DataAccessLayer, to match our previous steps.
namespace DataAccessLayer
{
    public class EmployeeDAO
    {
        // 1. Re-implement the Singleton Pattern
        private static EmployeeDAO instance = null;
        private static readonly object instanceLock = new object();
        public EmployeeDAO() { }
        public static EmployeeDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new EmployeeDAO();
                    }
                    return instance;
                }
            }
        }

        // 2. Add UserName and Password to your sample data
        private List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeID = 1, Name = "Admin", UserName = "admin", Password = "1", JobTitle = "Administrator" },
            new Employee { EmployeeID = 2, Name = "Staff", UserName = "staff", Password = "1", JobTitle = "Staff" },
            new Employee { EmployeeID = 3, Name = "John Doe", UserName = "john", Password = "123", JobTitle = "Software Engineer" },
            new Employee { EmployeeID = 4, Name = "Jane Smith", UserName = "jane", Password = "123", JobTitle = "Project Manager" }
        };

        // 3. Make methods non-static (instance methods) to be called via the Singleton instance

        public List<Employee> GetEmployees() => new List<Employee>(employees);

        public Employee? GetEmployeeById(int id) =>
            employees.FirstOrDefault(e => e.EmployeeID == id);

        public void AddEmployee(Employee employee) =>
            employees.Add(employee);

        public void UpdateEmployee(Employee employee)
        {
            var existing = employees.FirstOrDefault(e => e.EmployeeID == employee.EmployeeID);
            if (existing != null)
            {
                existing.Name = employee.Name;
                existing.JobTitle = employee.JobTitle;
                // Add other properties as needed
            }
        }

        public void DeleteEmployee(int id)
        {
            var toRemove = employees.FirstOrDefault(e => e.EmployeeID == id);
            if (toRemove != null)
            {
                employees.Remove(toRemove);
            }
        }

        // 4. Use the original login method that our ViewModel expects
        public Employee? GetEmployeeByUsernameAndPassword(string username, string password)
        {
            return employees.FirstOrDefault(e => e.UserName.Equals(username) && e.Password.Equals(password));
        }

        public Employee Login(string userName, string password) =>
            employees.FirstOrDefault(e => e.UserName == userName && e.Password == password);
    }
}