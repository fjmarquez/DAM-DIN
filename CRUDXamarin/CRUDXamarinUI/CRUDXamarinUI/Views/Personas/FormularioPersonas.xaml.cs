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

        FormularioPersonasVM viewmodelFormulario;

        public FormularioPersonas()
        {
            InitializeComponent();
        }

        public FormularioPersonas(clsPersona persona)
        {
            InitializeComponent();
            viewmodelFormulario = (FormularioPersonasVM) this.BindingContext;

            //Ocultamos el label correspondiente al id y el boton destinado a borrar cuando el id de la persona recibida sea 0, lo cual quiere decir que es un objeto persona nuevo/vacio
            if(persona.Id == 0)
            {
                labelId.IsVisible = false;
                labelIdPersona.IsVisible = false;
                ToolbarItems.Remove(btnBorrarPersona);
            }

            viewmodelFormulario.PersonaFormulario = persona;
            
        }

        private void btnBorrarPersona_Clicked(object sender, EventArgs e)
        {
            viewmodelFormulario.CommandBorrar.Execute(null);
        }

        private void btnGuardarPersona_Clicked(object sender, EventArgs e)
        {
            //viewmodelFormulario.CommandGuardar.Execute(null);
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}