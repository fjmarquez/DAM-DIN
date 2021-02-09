using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDINGrupo2Entities
{
    public class clsCliente
    {

        #region Privadas

        private int id;
        private Double saldo;
        private string nombre;
        private string pin;

        #endregion



        #region Publicas

        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public double Saldo
        {
            get
            {
                return saldo;
            }
            set
            {
                saldo = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
            }
        }

        public string Pin
        {
            get
            {
                return pin;
            }
            set
            {
                pin = value;
            }
        }

        #endregion



        #region Constructores

        public clsCliente()
        {
            this.id = 0;
            this.saldo = 0.0;
            this.nombre = "";
            this.pin = "0000";
        }

        public clsCliente(int id, double saldo, string nombre, string pin)
        {
            this.id = id;
            this.saldo = saldo;
            this.nombre = nombre;
            this.pin = pin;
        }

        #endregion



    }
}
