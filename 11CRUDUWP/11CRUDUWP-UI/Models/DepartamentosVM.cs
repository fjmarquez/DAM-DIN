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
    public class DepartamentosVM : INotifyPropertyChanged
    {

        #region Atributos

        private ObservableCollection<clsDepartamento> listadoDepartamentosFilter;
        private clsDepartamento departamentoSeleccionado;
        private clsDepartamento departamentoOriginal;
        private string toFilter;
        private DelegateCommand commandNuevo;
        private DelegateCommand commandEliminar;
        private DelegateCommand commandFiltrar;
        private DelegateCommand commandGuardar;

        #endregion

        #region Propiedades Publicas

        // Propiedad publica de tipo ObservableCollection que almacenara items del tipo clsDepartamento, esta sera la lista bindeada
        // con el ListView, sera la que cambie segun el filtrado por nombre
        public ObservableCollection<clsDepartamento> ListadoDepartamentosFilter
        {
            get
            {
                return listadoDepartamentosFilter;
            }
        }

        // Propiedad publica de tipo clsDepartamento que usaremos para almacenar el item (departamento) seleccionado
        // del listview (ListaDepartamentosFilter)
        public clsDepartamento DepartamentoSeleccionado
        {
            get
            {
                return departamentoSeleccionado;
            }
            set
            {
                //commandGuardar.RaiseCanExecuteChanged();
                if (this.departamentoSeleccionado != value && value != null)
                {
                    this.departamentoSeleccionado = value;

                    this.departamentoOriginal = new clsDepartamento(value);

                    NotifyPropertyChanged("DepartamentoSeleccionado");//Notifica cambios realizados mediante bindeo

                    commandEliminar.RaiseCanExecuteChanged();//Ejecutamos el metodo privado EliminarCommand_CanExecute

                }
            }
        }

        //Propiedad public de tipo clsDepartamento que almacenara los datos del departamento seleccionado, para mas tarde,
        //cuando modifiquemos el departamento seleccionado podamos cotejar los cambios.
        public clsDepartamento DepartamentoOriginal
        {
            get
            {
                return departamentoOriginal;
            }
            set
            {
                this.departamentoOriginal = value;
            }
        }

        // Propiedad publica de tipo String que Usaremos para almacenar el texto introducido en el TextBox destinado
        // a filtrar el ListView (ListaDepartamentosFilter) por nombre
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


                    listadoDepartamentosFilter.Clear();

                    this.listadoDepartamentosFilter = new ObservableCollection<clsDepartamento>(new clsListadoDepartamentosBL().getListadoDepartamentos());

                    NotifyPropertyChanged("ListadoDepartamentosFilter");

                }
            }
        }

        //Command que seteara DepartamentoSeleccionado a NULL, limpiando asi los TextBox
        public DelegateCommand CommandNuevo
        {
            get
            {
                commandNuevo = new DelegateCommand(CommandNuevo_Execute);
                return commandNuevo;
            }
        }

        //Command que eliminara el departamento seleccionado de la BD y despues volvera a cargar la lista
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

        //Command que moficara o insertara un nuevo departamento en la base de datos y despues se actualizara la lista para mostrar los cambios en este
        public DelegateCommand CommandGuardar
        {
            get
            {
                commandGuardar = new DelegateCommand(CommandGuardar_Execute, CommandGuardar_CanExecute);
                return commandGuardar;
            }

        }


        #endregion


        #region Contructores

        /// <summary>
        /// Contructor por defecto
        /// </summary>
        public DepartamentosVM()
        {

            try
            {
                
                //Rellenamos el listado de departamentos
                this.listadoDepartamentosFilter = new ObservableCollection<clsDepartamento>(new clsListadoDepartamentosBL().getListadoDepartamentos());
                //Inicializamos el departamentos seleccionado
                this.departamentoSeleccionado = new clsDepartamento();

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
        /// Este command se ejecutara directamente, su funcion es vaciar los textBox y 'reiniciar' la variable departamentoSeleccionado
        /// </summary>
        private void CommandNuevo_Execute()
        {

            if (this.departamentoSeleccionado != null && this.departamentoSeleccionado.Id != 0)
            {

                this.departamentoSeleccionado = null;


                NotifyPropertyChanged("DepartamentoSeleccionado");

            }
            if (this.departamentoSeleccionado == null)
            {
                this.departamentoSeleccionado = new clsDepartamento();

                this.departamentoSeleccionado.Id = 0;
                this.departamentoSeleccionado.Departamento = "";

                NotifyPropertyChanged("DepartamentoSeleccionado");
            }

            commandEliminar.RaiseCanExecuteChanged();
            commandGuardar.RaiseCanExecuteChanged();

            //this.personaSeleccionada = new clsPersona(); AÑADIR ESTA LINEA CUANDO VAYAMOS A RECOGER LOS DATOS DE UNA NUEVA PERSONA
        }
        #endregion

        #region commnadEliminar
        /// <summary>
        /// Esta funcion determinara si se puede ejecutar el commandEliminar, comprueba que hemos seleccionado algun departamento antes
        /// </summary>
        /// <returns></returns>
        private bool CommandEliminar_CanExecute()
        {
            bool btnEliminarEstado = false;
            if (this.departamentoSeleccionado != null && this.departamentoSeleccionado.Id != 0)
            {
                btnEliminarEstado = true;
            }
            return btnEliminarEstado;
        }

        /// <summary>
        /// Esta funcion se ejecutara si su CanExecute correspondiente devuelve true, se encarga de eliminar un departamento de la BD,
        /// ademas recarga la lista y muestra mensajes tanto de exito como de error
        /// </summary>
        async void CommandEliminar_Execute()
        {

            try
            {

                ContentDialog noWifiDialog = new ContentDialog
                {
                    Title = "Eliminar departamento",
                    Content = "¿Desea eliminar el departamento seleccionado?",
                    PrimaryButtonText = "Eliminar",
                    SecondaryButtonText = "Cerrar"
                };

                ContentDialogResult result = await noWifiDialog.ShowAsync();

                if (result == ContentDialogResult.Primary)
                {
                    int countField = new clsHandlerDepartamentoBL().deleteDepartamentoBL(this.departamentoSeleccionado.Id);

                    this.departamentoSeleccionado.Id = 0;
                    this.departamentoSeleccionado.Departamento = "";

                    NotifyPropertyChanged("DepartamentoSeleccionado");

                    listadoDepartamentosFilter.Clear();

                    this.listadoDepartamentosFilter = new ObservableCollection<clsDepartamento>(new clsListadoDepartamentosBL().getListadoDepartamentos());

                    NotifyPropertyChanged("ListadoDepartamentosFilter");

                    if (countField == 1)
                    {
                        ContentDialog eliminarOkDialog = new ContentDialog
                        {
                            Title = "Departamento eliminado correctamente",
                            Content = "El departamento seleccionado se ha eliminado correctamente",
                            CloseButtonText = "Ok"
                        };

                        ContentDialogResult result2 = await eliminarOkDialog.ShowAsync();
                    }else if (countField == -1)
                    {
                        ContentDialog eliminarImposibleDialog = new ContentDialog
                        {
                            Title = "No se puede eliminar el departamento seleccionado",
                            Content = "El departamento seleccionado no puede ser eliminar, ya que existen personas con dicho departamento asignado",
                            CloseButtonText = "Ok"
                        };

                        ContentDialogResult result2 = await eliminarImposibleDialog.ShowAsync();
                    }

                }

                commandGuardar.RaiseCanExecuteChanged();
                commandEliminar.RaiseCanExecuteChanged();

            }
            catch
            {
                ContentDialog eliminarFalloDialog = new ContentDialog
                {
                    Title = "Error al eliminar departamento",
                    Content = "Ha ocurrido un error mientra se eliminaba el departamento seleccionado",
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
        /// filtrando por nombre de departamento y actualiza la lista con los resultados correspondientes, en caso de error o de no haber 
        /// encontrado resultados mostrara mensajes de error.
        /// </summary>
        async void CommandFiltar_Execute()
        {

            try
            {

                commandNuevo.Execute(commandNuevo);

                NotifyPropertyChanged("DepartamentoSeleccionado");

                listadoDepartamentosFilter.Clear();

                this.listadoDepartamentosFilter = new ObservableCollection<clsDepartamento>(new clsListadoDepartamentosBL().getListadoDepartamentosPorNombre(this.toFilter));

                NotifyPropertyChanged("ListadoDepartamentosFilter");

                if (this.listadoDepartamentosFilter.Count == 0)
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
        /// Esta funcion comprueba si podemos ejecutar el commandGuardar, para ello comprueba primero si estamos creando o editanto un departamento,
        /// y despues en caso de estar editando un departamento cotejara sus propiedades con una copia de departamentoSelccionado realizado anteriormente.
        /// </summary>
        /// <returns></returns>
        private bool CommandGuardar_CanExecute()
        {
            bool btnModificarEstado = false;
            if (this.departamentoSeleccionado != null)
            {
                if (this.departamentoSeleccionado.Id == 0 && this.departamentoSeleccionado.Departamento.Length > 3)
                {
                    btnModificarEstado = true;
                }
                else if (this.departamentoSeleccionado.Id != 0)
                {

                    if (departamentoOriginal.Departamento != this.departamentoSeleccionado.Departamento)
                    {
                        btnModificarEstado = true;
                    }
                }


            }

            return btnModificarEstado;
        }

        /// <summary>
        /// Esta fucion se podra ejecutar si su CanExecute correspondiente devuelve true y se encarga de crear o editar un departamento,
        /// mostrara mensajes tanto de error como de exito en las operaciones que ejecutara.
        /// </summary>
        async void CommandGuardar_Execute()
        {

            try
            {

                if (this.departamentoSeleccionado.Id != 0)
                {
                    int countField = new clsHandlerDepartamentoBL().updateDepartamentoBL(this.departamentoSeleccionado);

                    if (countField == 1)
                    {
                        ContentDialog GuardarFalloDialog = new ContentDialog
                        {
                            Title = "Datos del departamento actualizados correctamente",
                            Content = "Se han actualizado correctamente los datos del departamento seleccionado",
                            CloseButtonText = "Ok"
                        };

                        ContentDialogResult result = await GuardarFalloDialog.ShowAsync();
                    }

                }
                else
                {
                    int countField = new clsHandlerDepartamentoBL().createDepartamentoBL(this.departamentoSeleccionado);

                    if (countField == 1)
                    {
                        ContentDialog CrearDialog = new ContentDialog
                        {
                            Title = "Departamento creado correctamente",
                            Content = "Se ha creado correctamente el departamento",
                            CloseButtonText = "Ok"
                        };

                        ContentDialogResult result = await CrearDialog.ShowAsync();
                    }

                }


                listadoDepartamentosFilter.Clear();

                this.listadoDepartamentosFilter = new ObservableCollection<clsDepartamento>(new clsListadoDepartamentosBL().getListadoDepartamentos());

                /*

                SI DESEO QUE DESPUES DE GUARDAR SE SIGAN MOSTRANDO LOS DATOS DE LA PERSONA SELECCIONADA ANTERIORMENTE,
                DEBO GUARDAR EL ID DE LA PERSONA ANTES DE LIMPIAR LA LISTA Y RELLENARLA CON LOS NUEVOS DATOS,
                PARA DESPUES OBTENERLA MEDIANTE EL METODO GETPERSONAPORID Y SETEARLA A PERSONASELECCIONADA

                 */

                NotifyPropertyChanged("ListadoDepartamentosFilter");
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

        #region Eventos 

        /// <summary>
        /// Evento que detecta cualquier cambio en un textBox y ejecuta el CanExecute del commandGuardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void EventoCambioTexto(object sender, TextChangedEventArgs e)
        {
            commandGuardar.RaiseCanExecuteChanged();
        }

        #endregion


        #endregion

    }
}
