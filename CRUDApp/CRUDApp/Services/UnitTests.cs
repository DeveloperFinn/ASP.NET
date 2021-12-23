using CRUDApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CRUDApp.Services
{
    public class UnitTests
    {
        private ApiEmployeeService _apiEmployeeService;

        [Fact]
        //Als de id 1 is, verwachten we ook 1 terug als we het id opvragen van die Employee
        public void Request_Right_Id_Of_Employees()
        {
            int id = 1;
            Assert.Equal(1, _apiEmployeeService.GetEmployee(id).Id);
        }



        //Als we vooraf weten hoeveel Employees we hebben, kunnen we even testen hoeveel employees er werkelijk aanwezig zijn
         public void Request_Right_Amount_Of_Employees()
        {
            int amount = 10;

            Assert.Equal(amount, Count(_apiEmployeeService.GetEmployees()));
        }
        public int Count(IEnumerable<Employee> employees)
        {
            int count = 0;
            foreach (var employee in employees)
                count++;
            return count;
        }
    }
}
