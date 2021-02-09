using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace _15HelloWorldXamarinUI
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            String nombre = entryNombre.Text.ToString();
            txtSaludo.Text = "Hola" + nombre;
            dialog(nombre);
        }

        private async Task dialog(String nombre)
        {
            await DisplayAlert("Hello World", "Hola " + nombre, "OK");
        }
    }
}
