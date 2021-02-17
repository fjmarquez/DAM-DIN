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
        //Instanciamos el viewmodel correspondiente
        PersonasListadoVM viewmodelListado;
        public Personas()
        {
            InitializeComponent();
            
            //Inicializamos el viewmodel
            viewmodelListado = (PersonasListadoVM)this.BindingContext;
            
        }

        /// <summary>
        /// Esta funcion OnAppearing se ejecutara cuando la vista vuelva del segundo plano
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            
            //'Deseleccionamos' el item seleccionado de la lista
            listaPersonas.SelectedItem = null;

            //llamar a oninit de personaslistadoVM para refrescar la lista
            viewmodelListado.onInit();
        }
    }
}