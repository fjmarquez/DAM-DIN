using CRUDXamarinBL.ListadosBL;
using CRUDXamarinEntities;
using CRUDXamarinUI.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarinUI.Models
{
    public class PersonasListadoVM : INotifyPropertyChanged
    {

        #region Atributos privados

        private ObservableCollection<clsPersona> listadoPersonas;
        private clsPersona personaSeleccionada;

        #endregion


        #region Propiedades publicas

        //Propiedad publica de listadoPersonas
        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get
            {
                return listadoPersonas;
            }
        }

        //Propiedad publica de personaSeleccionada
        public clsPersona PersonaSeleccionada
        {
            get
            {
                return personaSeleccionada;
            }
            set
            {
                if (this.personaSeleccionada != value && value != null)
                {
                    this.personaSeleccionada = value;
                    //Navegamos hacia la vista FormularioPersonas
                    Xamarin.Forms.Application.Current.MainPage.Navigation.PushAsync(new FormularioPersonas(personaSeleccionada));

                    this.personaSeleccionada = null;
                }
            }
        }
        #endregion


        #region Constructores
        /// <summary>
        /// Constructor por defecto de la clase PersonasListadoVM
        /// </summary>
        public PersonasListadoVM()
        {
            onInit();

        }

        /// <summary>
        /// Funcion asincrona donde inicializamos listadoPersonas, a traves de la capa BL
        /// </summary>
        public async void onInit()
        {
            
            this.listadoPersonas = new ObservableCollection<clsPersona>(await new clsListadosPersonasBL().getListadoPersonasBL());
            NotifyPropertyChanged("ListadoPersonas");

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


        #endregion

    }
}
