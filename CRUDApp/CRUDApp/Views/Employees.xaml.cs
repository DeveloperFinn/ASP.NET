using CRUDApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Employees : ContentPage
    {

        private readonly EmployeesViewModel _employeeViewModel;
        public Employees()
        {
            InitializeComponent();
            _employeeViewModel = Startup.Resolve<EmployeesViewModel>();
            BindingContext = _employeeViewModel;
        }

        protected override void OnAppearing()
        {
            _employeeViewModel?.PopulateEmployees();
        }
    }
}