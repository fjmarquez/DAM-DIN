using CRUDXamarinEntities;
using CRUDXamarinUI.Models.Personas;
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
    public partial class FormularioPersonas : ContentPage
    {
        //Instanciamos el Viewmodel correspondiente
        FormularioPersonasVM viewmodelFormulario;

        public FormularioPersonas()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor que recibira un objeto clsPersona y da el valor de este a personaFormulario (propiedad del Viewmodel)
        /// </summary>
        /// <param name="persona"></param>
        public FormularioPersonas(clsPersona persona)
        {
            InitializeComponent();
            //Inicializamos el viewmodel
            viewmodelFormulario = (FormularioPersonasVM) this.BindingContext;

            //Ocultamos el label correspondiente al id y el boton destinado a borrar cuando el id de la persona recibida sea 0, lo cual quiere decir que es un objeto persona nuevo/vacio
            if(persona.Id == 0)
            {
                labelId.IsVisible = false;
                labelIdPersona.IsVisible = false;
                ToolbarItems.Remove(btnBorrarPersona);
            }

            //Damos valor a la propiedad de personaFormulario
            viewmodelFormulario.PersonaFormulario = persona;
            
        }

        /// <summary>
        /// 'Evento' que se ejecutara cada vez que cambie el texto de un entry
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

            viewmodelFormulario.eventoTextChanged();

        }

        /// <summary>
        /// 'Evento' que se ejecutara cada vez que se cambie la fecha de un datepicker
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {

            viewmodelFormulario.eventoTextChanged();

        }
    }
}