using CRUDApp.Services;
using CRUDApp.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDApp
{
    public static class StartUp
    {
        private static IServiceProvider serviceProvider;
        public static void ConfigureServices()
        {
            var services = new ServiceCollection();

            //add http services
            //Allows us to register a service depending on the HTTP client
            //When the IEmployeeService will be resolved, the API will be implemented
            services.AddHttpClient<IEmployeeService, ApiEmployeeService>(c =>
            {
                c.BaseAddress = new Uri("http://10.0.2.2:52236/api/");
                c.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            //add viewmodels
            services.AddTransient<EmployeesViewModel>();
            services.AddTransient<AddEmployeeViewModel>();
            services.AddTransient<EmployeeDetailsViewModel>();

            serviceProvider = services.BuildServiceProvider();
        }

        public static T Resolve<T>() => serviceProvider.GetService<T>();
    }
}
