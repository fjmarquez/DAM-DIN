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
                    
                    //Con esto me aseguro que la variable personaOriginal no cambia
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

                    this.personaFormulario.IdDepartamento = this.departamentoPersonaFormulario.Id;
                    NotifyPropertyChanged("PersonaFormulario");
                    CommandGuardar.RaiseCanExecuteChanged();

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

        //Command destinado a guardar los cambios en una persona o crear una persona nueva
        public DelegateCommand CommandGuardar { get; }

        //Command destinado a eliminar la persona que estamos visualizando en el formulario
        public DelegateCommand CommandBorrar { get; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor por defecto del ViewModel destinado a la vista FormularioPersonas
        /// </summary>
        public FormularioPersonasVM()
        {

            onInit();

            flagPersonaOriginal = true;

            //Inicializamos los commands
            CommandGuardar = new DelegateCommand(CommandGuardar_Execute, CommandGuardar_CanExecute);
            CommandBorrar = new DelegateCommand(CommandBorrar_Execute);

        }

        /// <summary>
        /// Funcion de tipo async que se usara para obtener los datos necesarios de la API de forma asincrona
        /// </summary>
        public async void onInit()
        {

            //Obtenemos un listado con todos los objetos departamentos
            this.listadoDepartamentos = new ObservableCollection<clsDepartamento>(await new clsListadosDepartamentosBL().getListadoDepartamentosBL());
            NotifyPropertyChanged("ListadoDepartamentos");
            
            //Le asignamos un valor a departamentoPersonaFormulario dependiendo del idDepartamento de personaFormulario
            foreach (clsDepartamento d in listadoDepartamentos)
            {
                if(d.Id == personaFormulario.IdDepartamento)
                {
                    //Definimos el valor que tendra deparamentoPersonaFormulario en funcion del idDepartamento de personaFormulario
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

        /// <summary>
        /// Metodo Can_Execute del commandGuardar, comprobara que la persona ha sido modificada y devolvera true o false
        /// en funcion de eso
        /// </summary>
        /// <returns></returns>
        private bool CommandGuardar_CanExecute()
        {

            bool btnGuardarEstado = false;
            if(personaFormulario != null && personaOriginal != null)
            {
                if(personaFormulario.Id != 0)
                {
                    if (personaFormulario.Nombre != personaOriginal.Nombre ||
                        personaFormulario.Apellidos != personaOriginal.Apellidos ||
                        personaFormulario.Direccion != personaOriginal.Direccion ||
                        personaFormulario.FechaNacimiento != personaOriginal.FechaNacimiento ||
                        personaFormulario.Telefono != personaOriginal.Telefono ||
                        personaFormulario.IdDepartamento != personaOriginal.IdDepartamento)
                    {
                        btnGuardarEstado = true;
                    }
                }
                else
                {
                    if (personaFormulario.Nombre.Length > 3    &&
                        personaFormulario.Apellidos.Length > 3 &&
                        personaFormulario.Direccion.Length > 3 &&
                        personaFormulario.Telefono.Length >= 9)
                    {
                        btnGuardarEstado = true;
                    }
                }
                

            }
            
            return btnGuardarEstado;
        }

        /// <summary>
        /// Metodo Execute del commmandGuardar, dependiendo del id de personaFormuario insertara una nueva persona o 
        /// modificara una existente, al finalizar mostrara un dialogo informando sobre la accion realizada o si ha ocurrido algun error
        /// </summary>
        private async void CommandGuardar_Execute()
        {
            HttpStatusCode statusCode;

            if (personaFormulario.Id == 0)
            {
                //Si personaFormulario.id es 0, estaremos creando una nueva persona
                statusCode = await new clsHandlersPersonasBL().insertarPersonaBL(personaFormulario);
            }
            else
            {
                //Si personaFormulario.id es distinto de 0, estaremos modificando una persona existente
                statusCode = await new clsHandlersPersonasBL().actualizarPersonaBL(personaFormulario);
            }
            

            if(statusCode == HttpStatusCode.Created)
            {
                await Application.Current.MainPage.DisplayAlert("Editar Persona", "Persona modificada con exito", "OK");
            }else if(statusCode == HttpStatusCode.OK)
            {
                await Application.Current.MainPage.DisplayAlert("Crear Persona", "Persona creada con exito", "OK");
            }
            else
            {
                await Application.Current.MainPage.DisplayAlert("Error al editar persona", "Parece que hemos tenido un problema al editar a la persona", "Volver");
            }

            //Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new Views.Personas()); De esta forma añade el formulario a la pila y se puede volver al formulario con los datos de la persona eliminada
            await Xamarin.Forms.Application.Current.MainPage.Navigation.PopAsync();

        }

        #endregion

        #region CommandBorrar

        /// <summary>
        /// Metodo Execute del commandBorrar, eliminara a personaFormulario mediante la API y volvera a la lista de personas (recargandola)
        /// </summary>
        private async void CommandBorrar_Execute()
        {

            String msgDialog = "¿Desea eliminar a " + personaFormulario.Nombre + " " + personaFormulario.Apellidos + "?";
            bool answer = await Application.Current.MainPage.DisplayAlert("Eliminar persona", msgDialog, "Borrar", "Cancelar");

            if(answer == true)
            {

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

        #region Utilidades

        /// <summary>
        /// Esta funcion sustituye el funcionamiento de un evento, cada vez que se llame desde el codigo behind 
        /// de la vista se ejecutara el CanExecute del commandGuardar
        /// </summary>
        public void eventoTextChanged()
        {

            CommandGuardar.RaiseCanExecuteChanged();

        }

        #endregion

    }
}
