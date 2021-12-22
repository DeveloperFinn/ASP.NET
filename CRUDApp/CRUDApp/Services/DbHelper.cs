using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CRUDApp.Models;
using SQLite;

namespace CRUDApp.Services
{
    public class DbHelper
    {
        private readonly SQLiteAsyncConnection _db;

        public DbHelper(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);
            _db.CreateTableAsync<Employee>();
        }

        public Task<List<Employee>> GetEmployeesAsync()
        {
            return _db.Table<Employee>().ToListAsync();
        }

        public Task<int> SaveEmployeeAsync(Employee employee)
        {
            return _db.InsertAsync(employee);
        }

        public Task<int> UpdateEmployeeAsync(Employee employee)
        {
            return _db.UpdateAsync(employee);
        }

        public Task<int> DeleteEmployeeAsync(Employee employee)
        {
            return _db.DeleteAsync(employee);
        }

    }
}
