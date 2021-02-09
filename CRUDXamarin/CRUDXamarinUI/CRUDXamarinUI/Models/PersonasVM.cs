using CRUDXamarinBL.ListadosBL;
using CRUDXamarinEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace CRUDXamarinUI.Models
{
    public class PersonasVM : INotifyPropertyChanged
    {

        #region Atributos privados

        private ObservableCollection<clsPersona> listadoPersonas;
        private clsPersona personaSeleccionada;

        #endregion


        #region Propiedades publicas

        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get
            {
                return listadoPersonas;
            }
        }

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

                }
            }
        }
        #endregion


        #region Getters y Setters


        #endregion


        #region Constructores

        public PersonasVM()
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
