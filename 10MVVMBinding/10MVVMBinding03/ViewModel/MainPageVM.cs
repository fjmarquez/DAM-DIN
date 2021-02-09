using _10MVVMBinding03.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10MVVMBinding03.ViewModel
{
    class MainPageVM
    {
        #region Atributos
        private clsPersona personaSeleccionada;
        private ObservableCollection<clsPersona> listadoPersonas;
        #endregion

        #region Propiedades publicas
        public event PropertyChangedEventHandler PropertyChanged;
        public clsPersona PersonaSeleccionada
        {
            get 
                { 
                return personaSeleccionada; 
                }
            set 
                {
                personaSeleccionada = value;
                INotifyPropertyChanged("PersonaSeleccionada");
                }
        }
        public ObservableCollection<clsPersona> ListadoPersonas 
        {
            get
                {
                return listadoPersonas;
                }
            set
                {
                listadoPersonas = value;
                }
        }
        #endregion

        #region Constructores
        //constructor por defecto
        public MainPageVM()
        {
            //Rellenamos la lista de personas
            this.listadoPersonas = new clsListado().listadoDePersonasCompleto();
        }
        #endregion


        #region NotifyPropertyChanged

        private void INotifyPropertyChanged(String property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        #endregion
    }
}
