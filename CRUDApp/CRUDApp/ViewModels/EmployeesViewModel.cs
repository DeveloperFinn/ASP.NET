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

        //Constructors
        public EmployeesViewModel()
        {

        }
        public EmployeesViewModel(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            Employees = new ObservableCollection<Employee>();
            DeleteEmployeeCommand = new Command<Employee>(async e => await DeleteEmployee(e));
            AddNewEmployeeCommand = new Command(async () => await GoToAddEmployeeView());
        }

        //Functions
        private async Task DeleteEmployee(Employee e)
        {
            await _employeeService.DeleteEmployee(e);
            await App.DbHelper.DeleteEmployeeAsync(e);
            PopulateEmployees();
        }


        private async Task GoToAddEmployeeView()
    => await Shell.Current.GoToAsync(nameof(AddEmployee));


        public async void PopulateEmployees()
        {
            try
            {
                Employees.Clear();

                var books = await _employeeService.GetEmployees();
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

        async void OnBookSelected(Employee employee)
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

        public Employee SelectedBook
        {
            get => selectedEmployee;
            set
            {
                if (selectedEmployee != value)
                {
                    selectedEmployee = value;

                    OnBookSelected(SelectedBook);
                }
            }
        }

        public ICommand DeleteEmployeeCommand { get; }

        public ICommand AddNewEmployeeCommand { get; }

    }

}
