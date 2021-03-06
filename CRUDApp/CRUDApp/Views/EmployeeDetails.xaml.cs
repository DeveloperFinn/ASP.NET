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
    public partial class EmployeeDetails : ContentPage
    {
        public EmployeeDetails()
        {
            InitializeComponent();

            BindingContext = StartUp.Resolve<EmployeeDetailsViewModel>();
        }
    }
}