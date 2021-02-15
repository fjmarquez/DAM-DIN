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
        PersonasListadoVM viewmodelListado;
        public Personas()
        {
            InitializeComponent();
            
            viewmodelListado = (PersonasListadoVM)this.BindingContext;
            
        }

        /// <summary>
        /// Esta funcion OnAppearing se ejecutara cuando la vista vuelva del segundo plano
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            listaPersonas.SelectedItem = null;

            //llamar a oninit de personaslistadoVM para refrescar la lista
            viewmodelListado.onInit();
        }

        /// <summary>
        /// Evento que se llevara a cabo cuando clickemos sobre el item del toolbar destinado a crear una nueva persona
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void btnNuevaPersona_Clicked(object sender, EventArgs e)
        {
            viewmodelListado.CommandNuevo.Execute(null);
        }
    }
}