using _11CRUDUWP_BL.Handlers;
using _11CRUDUWP_BL.Listados;
using _11CRUDUWP_Entities;
using _11CRUDUWP_UI.Models.Utils;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace _11CRUDUWP_UI.Models
{
    public class PersonasVM : INotifyPropertyChanged
    {
        #region Atributos

        private ObservableCollection<clsPersona> listadoPersonasFilter;
        private ObservableCollection<clsDepartamento> listadoDepartamentos;
        private clsPersona personaSeleccionada;
        private clsPersona personaOriginal;
        private string toFilter;
        private DelegateCommand commandNuevo;
        private DelegateCommand commandEliminar;
        private DelegateCommand commandFiltrar;
        private DelegateCommand commandGuardar;

        #endregion


        #region Propiedades Publicas

        // Propiedad publica de tipo ObservableCollection que almacenara items del tipo clsPersona, esta sera la lista bindeada
        // con el ListView, sera la que cambie segun el filtrado por nombre
        public ObservableCollection<clsPersona> ListadoPersonasFilter
        {
            get
            {
                return listadoPersonasFilter;
            }
        }

        public ObservableCollection<clsDepartamento> ListadoDepartamentos
        {
            get
            {
                return listadoDepartamentos;
            }
        }


        // Propiedad publica de tipo clsPersona que usaremos para almacenar el item (persona) seleccionada 
        // del listview (ListaPersonas)
        public clsPersona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
            set
            {
                //commandGuardar.RaiseCanExecuteChanged();
                if (this.personaSeleccionada != value && value != null)
                {
                    this.personaSeleccionada = value;

                    this.personaOriginal = new clsPersona(value);
                    
                    NotifyPropertyChanged("PersonaSeleccionada");//Notifica cambios realizados mediante bindeo

                    commandEliminar.RaiseCanExecuteChanged();//Ejecutamos el metodo privado EliminarCommand_CanExecute
                    
                }
            }
        }

        //Propiedad publica de tipo clsPersona que almacerana los datos de la persona seleccionada, para mas tarde
        //cuando modifiquemos persona seleccionada podamos cotejar los cambios.
        public clsPersona PersonaOriginal
        {
            get
            {
                return personaOriginal;
            }
            set
            {
                this.personaOriginal = value;
            }
        }

        // Propiedad publica de tipo String que Usaremos para almacenar el texto introducido en el TextBox destinado
        // a filtrar el ListView (ListaPersonas) por nombre
        public String ToFilter
        {
            get
            {
                return toFilter;
            }
            set
            {
                this.toFilter = value;
                commandFiltrar.RaiseCanExecuteChanged();//Ejecutamos el metodo privado FiltrarCommand_CanExecute
                if (String.IsNullOrEmpty(toFilter))
                {
                    commandNuevo.Execute(commandNuevo);


                    listadoPersonasFilter.Clear();

                    this.listadoPersonasFilter = new ObservableCollection<clsPersona>(new clsListadoPersonasBL().getListadoPersonas());

                    NotifyPropertyChanged("ListadoPersonasFilter");

                }
            }
        }

        //Command que seteara PersonaSeleccionada a NULL, limpiando asi los TextBox
        public DelegateCommand CommandNuevo
        {
            get
            {
                commandNuevo = new DelegateCommand(CommandNuevo_Execute);
                return commandNuevo;
            }
        }

        //Command que eliminara la persona seleccionada de la BD y despues volvera a cargar la lista
        public DelegateCommand CommandEliminar
        {
            get
            {
                commandEliminar = new DelegateCommand(CommandEliminar_Execute, CommandEliminar_CanExecute);
                return commandEliminar;
            }
        }

        //Command que filtrara la lista segun el texto bindeado a toFilter
        public DelegateCommand CommandFiltrar
        {
            get
            {
                commandFiltrar = new DelegateCommand(CommandFiltar_Execute, CommandFiltrar_CanExecute);
                return commandFiltrar;
            }
        }

        //Command que moficara o insertara una nueva persona en la base de datos y despues se actualizara la lista para mostrar los cambios en esta
        public DelegateCommand CommandGuardar
        {
            get{
                commandGuardar = new DelegateCommand(CommandGuardar_Execute, CommandGuardar_CanExecute);
                return commandGuardar;
            }
            
        }


        #endregion


        #region Constructores


        /// <summary>
        /// Constructor por defecto
        /// </summary>

        public PersonasVM()
        {
            try
            {
                //Rellenamos la lista de personas
                this.listadoPersonasFilter = new ObservableCollection<clsPersona>(new clsListadoPersonasBL().getListadoPersonas());
                //Rellenamos la lista de departamentos
                this.listadoDepartamentos = new ObservableCollection<clsDepartamento>(new clsListadoDepartamentosBL().getListadoDepartamentos());
                //Inicializamos la variable persona seleccionada
                this.personaSeleccionada = new clsPersona();
            }
            catch(Exception e)
            {

                throw e;

            }
            

        }

        #endregion


        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion


        #region Commands

        #region commandNuevo
        /// <summary>
        /// Este command se ejecutara directamente, su funcion es vaciar los textBox y 'reiniciar' la variable personaSeleccionada
        /// </summary>
        private void CommandNuevo_Execute()
        {
            if (this.personaSeleccionada != null && this.personaSeleccionada.Id != 0)
            {

                this.personaSeleccionada = null;

                //clsPersona pTmp = new clsPersona("", "", DateTime.Now, "", "", 1, null);

                NotifyPropertyChanged("PersonaSeleccionada");

            }
            if(this.personaSeleccionada == null)
            {
                this.personaSeleccionada = new clsPersona();

                this.personaSeleccionada.Id = 0;
                this.personaSeleccionada.Nombre = "";
                this.personaSeleccionada.Apellidos = "";
                this.personaSeleccionada.Direccion = "";
                this.personaSeleccionada.Telefono = "";
                this.personaSeleccionada.FechaNacimiento = DateTime.Now;
                this.personaSeleccionada.IdDepartamento = 1;

                NotifyPropertyChanged("PersonaSeleccionada");
            }

            commandEliminar.RaiseCanExecuteChanged();
            commandGuardar.RaiseCanExecuteChanged();

            //this.personaSeleccionada = new clsPersona(); AÑADIR ESTA LINEA CUANDO VAYAMOS A RECOGER LOS DATOS DE UNA NUEVA PERSONA
        }
        #endregion

        #region commnadEliminar
        /// <summary>
        /// Esta funcion determinara si se puede ejecutar el commandEliminar, comprueba que hemos seleccinado alguna persona de la lista
        /// </summary>
        /// <returns></returns>
        private bool CommandEliminar_CanExecute()
        {
            bool btnEliminarEstado = false;
            if (this.personaSeleccionada != null && this.personaSeleccionada.Id != 0)
            {
                btnEliminarEstado = true;
            }
            return btnEliminarEstado;
        }

        /// <summary>
        /// Esta funcion se ejecutara si su CanExecute correspondiente devuelve true, se encarga de eliminar una persona de la BD,
        /// ademas recarga la lista y muestra mensajes tanto de exito como de error
        /// </summary>
        async void CommandEliminar_Execute()
        {

            try
            {
                ContentDialog eliminarDialog = new ContentDialog
                {
                    Title = "Eliminar persona",
                    Content = "¿Desea eliminar la persona seleccionada?",
                    PrimaryButtonText = "Eliminar",
                    SecondaryButtonText = "Cerrar"
                };

                ContentDialogResult result = await eliminarDialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {

                    int countField = new clsHandlerPersonaBL().deletePersonaBL(this.personaSeleccionada.Id);

                    this.personaSeleccionada.Id = 0;
                    this.personaSeleccionada.Nombre = "";
                    this.personaSeleccionada.Apellidos = "";
                    this.personaSeleccionada.Direccion = "";
                    this.personaSeleccionada.Telefono = "";
                    this.personaSeleccionada.FechaNacimiento = new DateTime().Date;
                    this.personaSeleccionada.IdDepartamento = 1;

                    NotifyPropertyChanged("PersonaSeleccionada");

                    listadoPersonasFilter.Clear();

                    this.listadoPersonasFilter = new ObservableCollection<clsPersona>(new clsListadoPersonasBL().getListadoPersonas());

                    NotifyPropertyChanged("ListadoPersonasFilter");

                    if (countField == 1)
                    {
                        ContentDialog eliminarOkDialog = new ContentDialog
                        {
                            Title = "Persona eliminada correctamente",
                            Content = "La persona seleccionada se ha eliminado correctamente",
                            CloseButtonText = "Ok"
                        };

                        ContentDialogResult result2 = await eliminarOkDialog.ShowAsync();
                    }


                }

                commandGuardar.RaiseCanExecuteChanged();
                commandEliminar.RaiseCanExecuteChanged();
            }
            catch
            {
                ContentDialog eliminarFalloDialog = new ContentDialog
                {
                    Title = "Error al eliminar persona",
                    Content = "Ha ocurrido un error mientra se eliminaba la persona seleccionada",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result3 = await eliminarFalloDialog.ShowAsync();
            }
            
            
        }
        #endregion

        #region commandFiltrar
        /// <summary>
        /// Esta funcion se encarga de comprobar que podemos ejecutar el commandFiltrar, para ello comprueba que el textBox
        /// destinado a filtrar no esta vacio
        /// </summary>
        /// <returns></returns>
        private bool CommandFiltrar_CanExecute()
        {
            bool btnFiltrarEstado = false;
            if (toFilter != null && toFilter.Length > 0)
            {
                btnFiltrarEstado = true;
            }
            return btnFiltrarEstado;
        }

        /// <summary>
        /// Esta funcion se ejecutara si su CanExecute correspondiente devuelve true, se encarga de realizar una consulta a la BD
        /// filtrando por nombre de persona y actualiza la lista con los resultados correspondientes, en caso de error o de no haber 
        /// encontrado resultados mostrara mensajes de error.
        /// </summary>
        async void CommandFiltar_Execute()
        {
            try
            {
                commandNuevo.Execute(commandNuevo);

                NotifyPropertyChanged("PersonaSeleccinada");

                listadoPersonasFilter.Clear();

                this.listadoPersonasFilter = new ObservableCollection<clsPersona>(new clsListadoPersonasBL().getListadoPersonasFiltradasPorNombreYApellidos(this.toFilter));

                NotifyPropertyChanged("ListadoPersonasFilter");

                if (this.listadoPersonasFilter.Count == 0)
                {
                    ContentDialog FiltrarCerooDialog = new ContentDialog
                    {
                        Title = "No se han encontrado coincidencias",
                        Content = "No se han encontrado coincidencias en la busqueda",
                        CloseButtonText = "Ok"
                    };

                    ContentDialogResult result = await FiltrarCerooDialog.ShowAsync();
                }

            }
            catch
            {
                ContentDialog FiltrarFallooDialog = new ContentDialog
                {
                    Title = "Error al realizar el filtro",
                    Content = "Ha ocurrido un error mientra se filtraba",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result = await FiltrarFallooDialog.ShowAsync();
            }
            

        }
        #endregion

        #region CommandGuardar

        /// <summary>
        /// Esta funcion comprueba si podemos ejecutar el commandGuardar, para ello comprueba primero si estamos creando o editanto una persona,
        /// y despues en caso de estar editando una persona cotejara sus propiedades con una copia de personaSeleccionada realizada anteriormente.
        /// </summary>
        /// <returns></returns>
        private bool CommandGuardar_CanExecute()
        {
            bool btnModificarEstado = false;
            if (this.personaSeleccionada != null)
            {
                if(this.personaSeleccionada.Id == 0 && this.personaSeleccionada.Nombre.Length > 3)
                {
                    btnModificarEstado = true;
                }
                else if (this.personaSeleccionada.Id != 0)
                {

                    if (personaOriginal.Nombre != this.personaSeleccionada.Nombre ||
                        personaOriginal.Apellidos != this.personaSeleccionada.Apellidos ||
                        personaOriginal.Direccion != this.personaSeleccionada.Direccion ||
                        personaOriginal.Telefono != this.personaSeleccionada.Telefono ||
                        personaOriginal.IdDepartamento != this.personaSeleccionada.IdDepartamento)
                    {
                        btnModificarEstado = true;
                    }
                }
                
                
            }
            
            return btnModificarEstado;
        }

        /// <summary>
        /// Esta fucion se podra ejecutar si su CanExecute correspondiente devuelve true y se encarga de crear o editar una persona,
        /// mostrara mensajes tanto de error como de exito en las operaciones que ejecutara.
        /// </summary>
        async void CommandGuardar_Execute()
        {
            try
            {

                if (this.personaSeleccionada.Id != 0)
                {
                    int countField = new clsHandlerPersonaBL().updatePersonaBL(this.personaSeleccionada);

                    if (countField == 1)
                    {
                        ContentDialog ActualizarDialog = new ContentDialog
                        {
                            Title = "Datos de la persona actualizados correctamente",
                            Content = "Se han actualizado correctamente los datos de la persona seleccionada",
                            CloseButtonText = "Ok"
                        };

                        ContentDialogResult result = await ActualizarDialog.ShowAsync();
                    }

                }
                else
                {
                    int countField = new clsHandlerPersonaBL().createPersonaBL(this.personaSeleccionada);

                    if (countField == 1)
                    {
                        ContentDialog CrearDialog = new ContentDialog
                        {
                            Title = "Persona creada correctamente",
                            Content = "Se ha creado correctamente la persona",
                            CloseButtonText = "Ok"
                        };

                        ContentDialogResult result = await CrearDialog.ShowAsync();
                    }
                    

                }


                listadoPersonasFilter.Clear();

                this.listadoPersonasFilter = new ObservableCollection<clsPersona>(new clsListadoPersonasBL().getListadoPersonas());

                /*

                SI DESEO QUE DESPUES DE GUARDAR SE SIGAN MOSTRANDO LOS DATOS DE LA PERSONA SELECCIONADA ANTERIORMENTE,
                DEBO GUARDAR EL ID DE LA PERSONA ANTES DE LIMPIAR LA LISTA Y RELLENARLA CON LOS NUEVOS DATOS,
                PARA DESPUES OBTENERLA MEDIANTE EL METODO GETPERSONAPORID Y SETEARLA A PERSONASELECCIONADA

                 */

                NotifyPropertyChanged("ListadoPersonasFilter");
                commandGuardar.RaiseCanExecuteChanged();
            }
            catch
            {
                ContentDialog GuardarFalloDialog = new ContentDialog
                {
                    Title = "Error al guardar datos",
                    Content = "Ha ocurrido un error mientra se guardaban los nuevos datos",
                    CloseButtonText = "Ok"
                };

                ContentDialogResult result2 = await GuardarFalloDialog.ShowAsync();
            }


        }

        #endregion

        #endregion


        #region Eventos 

        /// <summary>
        /// Este evento se ejecutara cada vez que se registre un cambio en un textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EventoCambioTexto(object sender, TextChangedEventArgs e)
        {
            commandGuardar.RaiseCanExecuteChanged();
        }

        /// <summary>
        /// Este evento se ejecutara cada vez que se registre un cambio en un combobox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EventoCambioComboBox(object sender, SelectionChangedEventArgs e)
        {
            commandGuardar.RaiseCanExecuteChanged();
        }

        #endregion


    }
}
