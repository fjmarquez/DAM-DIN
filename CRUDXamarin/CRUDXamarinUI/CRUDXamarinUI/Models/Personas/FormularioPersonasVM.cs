using CRUDXamarinEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace CRUDXamarinUI.Models.Personas
{
    class FormularioPersonasVM : INotifyPropertyChanged
    {

        #region Atributos privados

        private clsPersona personaFormulario;

        #endregion

        #region Propiedades publicas

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

                    //this.personaFormulario = null;
                }
            }
        }

        #endregion

        #region Constructor

        public FormularioPersonasVM()
        {

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
