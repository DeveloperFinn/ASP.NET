using CRUDApp.Models;
using CRUDApp.Services;
using CRUDApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CRUDApp.ViewModels
{
    public class EmployeesViewModel : BaseViewModel
    {

        //Declarations
        private ObservableCollection<Employee> employees;
        private Employee selectedEmployee;
        private readonly IEmployeeService _employeeService;

        //Constructor
        public EmployeesViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            //This collection gets loaded into the EmployeesPage
            Employees = new ObservableCollection<Employee>();
            DeleteEmployeeCommand = new Command<Employee>(async e => await DeleteEmployee(e));
            AddNewEmployeeCommand = new Command(async () => await GoToAddEmployeeView());
        }

        //Functions
        private async Task DeleteEmployee(Employee e)
        {
            await _employeeService.DeleteEmployee(e);
            await App.DbHelper.DeleteEmployeeAsync(e);
            //Refresh the page
            PopulateEmployees();
        }


        //Rerouting
        private async Task GoToAddEmployeeView()
    => await Shell.Current.GoToAsync(nameof(AddEmployee));


        //Refreshing
        public async void PopulateEmployees()
        {
            try
            {
                Employees.Clear();

                var employees = await _employeeService.GetEmployees();
                foreach (var employee in employees)
                {
                    Employees.Add(employee);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //When employee is selected, go to the employeeDetailsPage where Id's match
        async void OnEmployeeSelected(Employee employee)
        {
            if (employee == null)
                return;

            await Shell.Current.GoToAsync($"{nameof(EmployeeDetails)}?{nameof(EmployeeDetailsViewModel.EmployeeId)}={employee.Id}");
        }

        public ObservableCollection<Employee> Employees
        {
            get => employees;
            set
            {
                employees = value;
                OnPropertyChanged(nameof(Employees));
            }
        }

        public Employee SelectedEmployee
        {
            get => selectedEmployee;
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;

                    OnEmployeeSelected(SelectedEmployee);
                }
            }
        }

        public ICommand DeleteEmployeeCommand { get; }

        public ICommand AddNewEmployeeCommand { get; }

    }

}
