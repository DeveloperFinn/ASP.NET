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
    public class AddEmployeeViewModel : BaseViewModel
    {
        private readonly IEmployeeService _employeeService;
        private string name;
        private string title;
        private string description;

        public AddEmployeeViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            SaveEmployeeCommand = new Command(async ()=> await SaveEmployee());
        }


        //Saving the employee
        private async Task SaveEmployee()
        {
            try
            {
                var employee = new Employee
                {
                    Name = Name,
                    Title = Title,
                    Description = Description
                };
                await _employeeService.SaveEmployee(employee);
                await App.DbHelper.SaveEmployeeAsync(employee);
                await Shell.Current.GoToAsync("..");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
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
