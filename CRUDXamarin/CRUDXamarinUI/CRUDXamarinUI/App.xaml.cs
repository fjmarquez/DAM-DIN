using CRUDXamarinUI.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDXamarinUI
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainMD());
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
