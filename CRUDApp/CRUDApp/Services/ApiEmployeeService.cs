using CRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CRUDApp.Services
{
    //Api implements the Interface Service
    public class ApiEmployeeService : IEmployeeService
    {
        private readonly HttpClient _httpClient;
        //We need to make a request to the web API
        //We make us of the HttpClient Class
        public ApiEmployeeService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task AddEmployee(Employee employee)
        {
            var response = await _httpClient.PostAsync("Books",
                //Payload of the request
                new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteEmployee(Employee employee)
        {
            var response = await _httpClient.DeleteAsync($"Employee/{employee.Id}");

            response.EnsureSuccessStatusCode();
        }

        public async Task<Employee> GetEmployee(int id)
        {
            var response = await _httpClient.GetAsync($"Employee/{id}");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Employee>(responseAsString);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var response = await _httpClient.GetAsync("Employees");
            response.EnsureSuccessStatusCode();

            var responseAsString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<Employee>>(responseAsString);
        }

        public async Task SaveEmployee(Employee employee)
        {
            var response = await _httpClient.PutAsync($"Books?id={employee.Id}",
                           //Payload of the request
                           new StringContent(JsonSerializer.Serialize(employee), Encoding.UTF8, "application/json"));

            response.EnsureSuccessStatusCode();
        }


    }
}
