using CRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployee(int id);
        Task AddEmployee(Employee employee);
        Task SaveEmployee(Employee employee);
        Task DeleteEmployee(Employee employee);
    }
}
