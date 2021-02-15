using CRUDXamarinBL.HandlersBL;
using CRUDXamarinBL.ListadosBL;
using CRUDXamarinEntities;
using CRUDXamarinUI.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text;
using Xamarin.Forms;
using CRUDXamarinUI.Views;

namespace CRUDXamarinUI.Models.Personas
{
    class FormularioPersonasVM : INotifyPropertyChanged
    {

        #region Atributos privados

        private clsPersona personaFormulario;
        private clsPersona personaOriginal;
        private bool flagPersonaOriginal;
        private clsDepartamento departamentoPersonaFormulario;
        private ObservableCollection<clsDepartamento> listadoDepartamentos;
        private Command commandGuardar;
        private DelegateCommand commandBorrar;


        #endregion

        #region Propiedades publicas

        //Propiedad que hace referencia al objeto persona que se mostrara en  el formulario
        public clsPersona PersonaFormulario
        {
            get
            {
                return personaFormulario;
            }
            set
            {
                if (this.personaFormulario != value && value != null)
                {
                    this.personaFormulario = value;
                    NotifyPropertyChanged("PersonaFormulario");
                    if(flagPersonaOriginal == false)
                    {
                        ((Command)commandGuardar).ChangeCanExecute();
                    }
                    

                    if (flagPersonaOriginal == true)
                    {
                        this.personaOriginal = new clsPersona(value);
                        flagPersonaOriginal = false;
                    }
                }
            }
        }

        //Propiedad que servira para obtener el item seleccionado del picker destinado a la eleccion de departamento de cada persona
        public clsDepartamento DepartamentoPersonaFormulario
        {
            get
            {
                return departamentoPersonaFormulario;
            }
            set
            {
                if (this.departamentoPersonaFormulario != value && value != null)
                {
                    this.departamentoPersonaFormulario = value;
                    NotifyPropertyChanged("DepartamentoPersonaFormulario");
                    //((Command)commandGuardar).ChangeCanExecute();

                    this.personaFormulario.IdDepartamento = this.departamentoPersonaFormulario.Id;
                    NotifyPropertyChanged("PersonaFormulario");

                }
            }
        }

        //Propiedad que almacenara el listado de departamentos completo, lo cual sera usado para rellenar el picker destinado a la eleccion de departamento de cada persona
        public ObservableCollection<clsDepartamento> ListadoDepartamentos
        {
            get
            {
                return listadoDepartamentos;
            }
        }

        public Command CommandGuardar
        {
            get
            {
                commandGuardar = new Command(CommandGuardar_Execute);
                return commandGuardar;
            }
        }

        public DelegateCommand CommandBorrar
        {
            get
            {
                commandBorrar = new DelegateCommand(CommandBorrar_Execute);
                return commandBorrar;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto del ViewModel destinado a la vista FormularioPersonas
        /// </summary>
        public FormularioPersonasVM()
        {

            onInit();
            flagPersonaOriginal = true;

        }

        /// <summary>
        /// Funcion de tipo async que se usara para obtener los datos necesarios de la API de forma asincrona
        /// </summary>
        public async void onInit()
        {

            this.listadoDepartamentos = new ObservableCollection<clsDepartamento>(await new clsListadosDepartamentosBL().getListadoDepartamentosBL());
            NotifyPropertyChanged("ListadoDepartamentos");

            /*
            this.departamentoPersonaFormulario = new clsDepartamento(await new clsListadosDepartamentosBL().getDepartamentoPorIDBL(personaFormulario.IdDepartamento));
            NotifyPropertyChanged("DepartamentoPersonaFormulario");
            */
            
            //Le asignamos un valor a departamentoPersonaFormulario dependiendo del idDepartamento de personaFormulario
            foreach (clsDepartamento d in listadoDepartamentos)
            {
                if(d.Id == personaFormulario.IdDepartamento)
                {
                    departamentoPersonaFormulario = d;
                    NotifyPropertyChanged("DepartamentoPersonaFormulario");
                    break;
                }
            }
            
        }

        #endregion

        #region NotifyPropertyChange

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion


        #region DelegateCommands

        #region CommandGuardar

        private async void CommandGuardar_Execute()
        {
            //TODO llamar a PUT en la API con el objeto de la persona modificado
            //throw new NotImplementedException();

            HttpStatusCode statusCode = await new clsHandlersPersonasBL().actualizarPersonaBL(PersonaFormulario);

            if(statusCode == HttpStatusCode.Created)
            {
                await Application.Current.MainPage.DisplayAlert("Editar Persona", "Persona modificada con exito", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error al editar persona", "Parece que hemos tenido un problema al editar a la persona", "Volver");
            }

            //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Views.Personas()); De esta forma añade el formulario a la pila y se puede volver al formulario con los datos de la persona eliminada
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();

        }

        #endregion

        #region CommandGuardar

        private async void CommandBorrar_Execute()
        {
            String msgDialog = "¿Desea eliminar a " + personaFormulario.Nombre + " " + personaFormulario.Apellidos + "?";
            bool answer = await Application.Current.MainPage.DisplayAlert("Eliminar persona", msgDialog, "Borrar", "Cancelar");

            if(answer == true)
            {

                //Llamada a delete de la API con el id de la persona y navegacion hacia atras

                HttpStatusCode statusCode = await new clsHandlersPersonasBL().borrarPersonaBL(personaFormulario.Id);

                if(statusCode == HttpStatusCode.NoContent)
                {
                    await Application.Current.MainPage.DisplayAlert("Eliminar persona", "Persona eliminada con exito", "Volver");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error al eliminar persona", "Parece que hemos tenido un problema al eliminar a la persona", "Volver");
                }

                //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Views.Personas()); De esta forma añade el formulario a la pila y se puede volver al formulario con los datos de la persona eliminada
                await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();

            }

        }

        #endregion

        #endregion

    }
}
