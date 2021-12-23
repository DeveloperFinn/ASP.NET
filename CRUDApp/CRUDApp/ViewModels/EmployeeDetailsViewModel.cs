using CRUDApp.Models;
using CRUDApp.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUDApp.ViewModels
{
    [QueryProperty(nameof(EmployeeId), nameof(EmployeeId))]
    public class EmployeeDetailsViewModel : BaseViewModel
    {
        private string employeeId;
        private string name;
        private string title;
        private string description;
        private readonly IEmployeeService _employeeService;

        public EmployeeDetailsViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            SaveEmployeeCommand = new Command(async ()=> await SaveEmployee());
        }


        private async Task SaveEmployee()
        {
            try
            {
                var employee = new Employee
                {
                    Id = int.Parse(EmployeeId),
                    Name = Name,
                    Title = Title,
                    Description = Description
                };

                await _employeeService.SaveEmployee(employee);
                await App.DbHelper.SaveEmployeeAsync(employee);
                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //Load in the employee that is Selected
        private async void LoadEmployee(string employeeId)
        {
            try
            {
                var employee = await _employeeService.GetEmployee(int.Parse(employeeId));
                if (employeeId != null)
                {
                    Name = employee.Name;
                    Title = employee.Title;
                    Description = employee.Description;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string EmployeeId
        {
            get => employeeId;
            set
            {
                employeeId = value;
                LoadEmployee(employeeId);
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand SaveEmployeeCommand { get; }
    }
}
