using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11_2_EventosYComandos01.Models
{
    public class clsPersona
    {

        private String nombre, apellidos, direccion;
        private int edad;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                //OnPropertyChanged("Nombre");
            }
        }
        public string Apellidos
        {
            get
            {
                return apellidos;
            }
            set
            {
                apellidos = value;
                //OnPropertyChanged("Apellidos");
            }
        }
        /*       public int Edad
               {
                   get
                   {
                       return edad;
                   }
                   set
                   {
                       edad = value;
                       //OnPropertyChanged("Edad");
                   }
               }
               public string Direccion
               {
                   get
                   {
                       return direccion;
                   }
                   set
                   {
                       direccion = value;
                       //OnPropertyChanged("Direccion");
                   }
               }
               public string NombreCompleto
               {
                   get
                   {
                       return nombre + " " + apellidos;
                   }
               }*/

        public clsPersona(String nombre, String apellidos/*, int edad, string direccion*/)
        {

            this.Nombre = nombre;
            this.Apellidos = apellidos;
            //this.Edad = edad;
            //this.Direccion = direccion;
        }

        public clsPersona()
        {
            //constructor por defecto

            this.Nombre = "Francisco";
            this.Apellidos = "Marquez";
            //this.Edad = 22;
            //this.Direccion = "";
        }

        /*
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }*/
    }
}