using CRUDXamarinEntities;
using CRUDXamarinUI.Models;
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
    public partial class Personas : ContentPage
    {
        public Personas()
        {
            InitializeComponent();
            BindingContext = new PersonasVM();
        }

        private async Task navigate(object sender, SelectedItemChangedEventArgs e)
        {

            clsPersona personaSeleccionada = (clsPersona)e.SelectedItem;

            await Navigation.PushAsync(new FormularioPersonas(personaSeleccionada));
        }

        private void listaPersonas_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

            navigate(sender, e);

        }
    }
}