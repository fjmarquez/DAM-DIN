using _11EventosYComandos01.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace _11EventosYComandos01.ViewModel
{
    public class MainPageVM
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
                this.personaSeleccionada = object(value);
                //OnPropertyChanged("PersonaSeleccionada");
            }


        }


        public ObservableCollection<clsPersona> ListadoPersonas
        {
            get { return listadoPersonas; }
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

        public void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(personaSeleccionada != null)
            {
                listadoPersonas.Remove(personaSeleccionada);
            }
        }

    }
}
