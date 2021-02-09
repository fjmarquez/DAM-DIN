using _11_2_EventosYComandos01.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace _11_2_EventosYComandos01.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged

        
    {
        #region Atributos
        private DelegateCommand eliminarCommand;
        private DelegateCommand dialogoEliminarCommand;
        private DelegateCommand filtrarCommand;
        private clsPersona personaSeleccionada;
        private ObservableCollection<clsPersona> listadoPersonas;
        private ObservableCollection<clsPersona> listadoPersonasFilter;
        private string toFilter;
        #endregion




        #region Propiedades publicas

        // Propiedad publica DialogoEliminarCommand, define las funciones para el command y devuelve el atributo privado filtrarCommand

        public DelegateCommand DialogoEliminarCommand
        {
            get
            {
                dialogoEliminarCommand = new DelegateCommand(DialogoEliminarCommand_Execute, DialogoEliminarCommand_CanExecute);
                return dialogoEliminarCommand;
            }
        }



        // Propiedad publica FiltrarCommand, define las funciones para el command y devuelve el atributo privado filtrarCommand

        public DelegateCommand FiltrarCommand
        {
            get
            {
                filtrarCommand = new DelegateCommand(FiltrarCommand_Execute, FiltrarCommand_CanExecute);
                return filtrarCommand;
            }
        }

        // Propiedad publica FiltrarCommand, define las funciones para el command y devuelve el atributo privado filtrarCommand

        public DelegateCommand EliminarCommand
        {
            get
            {
                eliminarCommand = new DelegateCommand(EliminarCommand_Execute, EliminarCommand_CanExecute);
                return eliminarCommand;
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
                if (this.personaSeleccionada != value)
                {
                    this.personaSeleccionada = value;
                    INotifyPropertyChanged("PersonaSeleccionada");//Notifica cambios realizados mediante bindeo
                    eliminarCommand.RaiseCanExecuteChanged();//Ejecutamos el metodo privado EliminarCommand_CanExecute
                    
                }
               
            }
        }

        
        // Propiedad publica de tipo String que Usaremos para almacenar el texto introducido en el TextBox destinado
        // a filtrar el ListView (ListaPersonas) por nombre
        
        public string ToFilter
        {
            get{
                return toFilter;
            }
            set
            {
                this.toFilter = value;
                filtrarCommand.RaiseCanExecuteChanged();//Ejecutamos el metodo privado FiltrarCommand_CanExecute
                if (String.IsNullOrEmpty(toFilter))
                {
                    this.listadoPersonasFilter = new ObservableCollection<clsPersona>(listadoPersonas);
                    INotifyPropertyChanged("ListadoPersonasFilter");
                    
                }
                //INotifyPropertyChanged("ToFilter");//Notifica cambios realizados mediante bindeo
            }
        }

        
        // Propiedad publica de tipo ObservableCollection que almacenara items del tipo clsPersona, esta variable la usaremos
        // para cotejar coincidencias con el texto recibido en ToFilter
        
        /*
        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get { return listadoPersonas; }
        }
        */
        
        
        // Propiedad publica de tipo ObservableCollection que almacenara items del tipo clsPersona, esta sera la lista bindeada
        // con el ListView, sera la que cambie segun el filtrado por nombre
        
        public ObservableCollection<clsPersona> ListadoPersonasFilter
        {
            get { return listadoPersonasFilter;  }

        }

        #endregion




        #region Constructores

        
        /// <summary>
        /// Constructor por defecto
        /// </summary>
        
        public MainPageVM()
        {
            //Rellenamos la lista de personas
            this.listadoPersonas = new clsListado().listadoDePersonasCompleto();
            this.listadoPersonasFilter = new clsListado().listadoDePersonasCompleto();

        }

        #endregion




        #region NotifyPropertyChanged

        /// <summary>
        /// Propiedad publica del tipo PropertyChangedEventHandler que usaremos en nuestro metodo privado INotifyPropertyChanged,
        /// encargado de notificar cambios en propiedades bindeadas
        /// </summary>
        
        public event PropertyChangedEventHandler PropertyChanged;

        private void INotifyPropertyChanged(String property)
        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
            /*
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }*/
        }

        #endregion




        #region Commands

        /// <summary>
        /// Comprueba si hay alguna persona seleccionada, en funcion de eso devuelve true (si hay una persona seleccionada) o
        /// false (si no hay una persona seleccionada
        /// </summary>
        /// <returns></returns>
        private bool EliminarCommand_CanExecute()
        {
            bool btnEliminarEstado = false;
            if (personaSeleccionada != null)
            {
                btnEliminarEstado = true;
            }
            return btnEliminarEstado;
        }

        /// <summary>
        /// Si EliminarCommand_CanExecute() devuelve true, ejecutamos la siguiente funcion, que elimina la persona selccionada de
        /// la lista
        /// </summary>
        private void EliminarCommand_Execute()
        {
            if (personaSeleccionada != null)
            {
                listadoPersonasFilter.Remove(personaSeleccionada);
            }
        }

        /// <summary>
        /// Comprueba si hay texto introducido en el TextBox destinado a filtrar por nombre, en funcion de eso devuelve true 
        /// (si el TextBox tiene texto) o false (si el TextBox esta vacio
        /// </summary>
        /// <returns></returns>
        private bool FiltrarCommand_CanExecute()
        {
            bool btnFiltrarEstado = false;
            if (toFilter != null && toFilter.Length > 0)
            {
                btnFiltrarEstado = true;
            }
            return btnFiltrarEstado;
        }

        /// <summary>
        /// Si FiltrarCommand_CanExecute devuelve true, ejecutamos la siguiente funcion, que filtra por nombre en la lista
        /// de personas
        /// </summary>
        private void FiltrarCommand_Execute()
        {
            if (toFilter != null && toFilter.Length > 0)
            {
                listadoPersonasFilter.Clear();
                foreach (clsPersona persona in listadoPersonas)
                {
                    if (persona.NombreCompleto.ToLower().Contains(ToFilter.ToLower()))
                    {
                        listadoPersonasFilter.Add(persona);
                    }
                }
            }
            
        }

        private bool DialogoEliminarCommand_CanExecute()
        {
            bool btnDialogoEliminarEstado = false;
            if (personaSeleccionada != null)
            {
                btnDialogoEliminarEstado = true;
            }
            return btnDialogoEliminarEstado;
        }

        async void DialogoEliminarCommand_Execute()
        {
            //listadoPersonasFilter.Remove(personaSeleccionada);
           

                ContentDialog noWifiDialog = new ContentDialog
                {
                    Title = "Eliminar persona",
                    Content = "¿Desea eliminar la persona seleccionada?",
                    PrimaryButtonText = "Eliminar",
                    PrimaryButtonCommand = EliminarCommand,
                    CloseButtonText = "Cerrar"
                };

                ContentDialogResult result = await noWifiDialog.ShowAsync();
            
        }

        #endregion


        //TODO
        //HACER QUE CUANDO SE BORRA UNA PERSONA SE BORRE ESTA DE LAS DOS PERSONAS


    }
}
