using CRUDApp.Models;
using CRUDApp.Services;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDApp
{
    public partial class App : Application
    {

        private static DbHelper database;

        public static DbHelper DbHelper
        {
            get
            {
                if (database == null)
                {
                    database = new DbHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "employees.db3"));
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
