using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CRUDXamarinUI.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async Task menuOpciones_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == "Personas")
            {
                await Navigation.PushAsync(new Personas());
            }
            else if(e.SelectedItem == "Departamentos")
            {
                await Navigation.PushAsync(new Departamentos());
            }
        }
    }
}