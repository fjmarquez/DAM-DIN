using ExamenDINGrupo2UI.ViewModels.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDINGrupo2UI.ViewModels
{
    public class loginVM : INotifyPropertyChanged
    {

        #region Atributos privados

        private String pinInsertado;
        private Boolean pinCorrecto;
        private DelegateCommand commandClear;
        private DelegateCommand commandDelete;
        private DelegateCommand commandEnter;

        #endregion

        #region Propiedades publicas

        public String PinInsertado
        {
            get
            {
                return pinInsertado;
            }
            set
            {
                this.pinInsertado = value;
            }
        }
        public Boolean PinCorrecto
        {
            get
            {
                return pinCorrecto;
            }
            set
            {
                this.pinCorrecto = value;
            }
        }

        public DelegateCommand CommandClear
        {
            get
            {
                commandClear = new DelegateCommand(CommandClear_Execute, CommandClear_CanExecute);
                return commandClear;
            }
        }

        public DelegateCommand CommandDelete
        {
            get
            {
                commandDelete = new DelegateCommand(CommandDelete_Execute, CommandDelete_CanExecute);
                return commandDelete;
            }
        }

        public DelegateCommand CommandEnter
        {
            get
            {
                commandEnter = new DelegateCommand(CommandEnter_Execute, CommandEnter_CanExecute);
                return commandEnter;
            }
        }

        #endregion

        #region Constructor

        public loginVM()
        {

        }

        #endregion

        #region NotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region Commands

        #region CommandDelete

        private bool CommandDelete_CanExecute()
        {
            throw new NotImplementedException();
        }

        private void CommandDelete_Execute()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CommandEnter

        private bool CommandEnter_CanExecute()
        {
            throw new NotImplementedException();
        }

        private void CommandEnter_Execute()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region CommandClear

        private bool CommandClear_CanExecute()
        {
            throw new NotImplementedException();
        }

        private void CommandClear_Execute()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

    }
}
