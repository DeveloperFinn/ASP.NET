using CRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDApp.Services
{
    class InMemoryEmployeeService : IEmployeeService
    {
        public List<Employee> _employees = new List<Employee>();

        //Adding an employee to the employeeList
        public Task AddEmployee(Employee employee)
        {
            //Incrementing the id (just taking the Last Id in there and adding it by 1)
            employee.Id = ++_employees.Last().Id;
            _employees.Add(employee);
            return Task.CompletedTask;
        }

        //Delete an employee from the employeeList 
        public Task DeleteEmployee(Employee employee)
        {
            _employees.Remove(employee);
            return Task.CompletedTask;
        }

        //Get an employee from the employeeList where the Id's match
        public Task<Employee> GetEmployee(int id)
        {
            var employee = _employees.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(employee);
        }

        //We are just returning the list as a whole in an Enumerable
        public Task<IEnumerable<Employee>> GetEmployees()
        {
            return Task.FromResult(_employees.AsEnumerable());
        }

        //Saving an employee where it originally came from.
        public Task SaveEmployee(Employee employee)
        {
            _employees[_employees.FindIndex(e => e.Id == employee.Id)] = employee;
            return Task.CompletedTask;
        }
    }
}
