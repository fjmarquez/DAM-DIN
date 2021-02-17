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
    public partial class Departamentos : ContentPage
    {
        //Viewmodel correspondiente a la vista
        DepartamentosListadoVM viewmodelListado;

        public Departamentos()
        {
            InitializeComponent();
            //Inicializacion del viewmodel
            viewmodelListado = (DepartamentosListadoVM)this.BindingContext;
        }

        /// <summary>
        /// Esta funcion OnAppearing se ejecutara cuando la vista vuelva del segundo plano
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            //'Deseleccionamos' el item seleccionado de la lista
            listaDepartamentos.SelectedItem = null;

            //Recargamos el listado
            viewmodelListado.onInit();
        }

    }
}