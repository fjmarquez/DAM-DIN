using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10MVVMBinding02.Models
{
    public class clsPersona : INotifyPropertyChanged
    {

        private String nombre, apellidos, edad;

        public string Nombre
        {
            get
            {
                return nombre;
            }
            set
            {
                nombre = value;
                OnPropertyChanged("Nombre");
            }
        }
        public string Apellidos { get; set; }
        public int Edad { get; set; }
        
                public clsPersona(String nombre, String apellidos, int edad)
                {
                    
                    this.Nombre = nombre;
                    this.Apellidos = apellidos;
                    this.Edad = edad;
                }

                public clsPersona()
                {
                    //constructor por defecto
                    
                    this.Nombre = "Francisco";
                    this.Apellidos = "Marquez";
                    this.Edad = 22;
                }
        

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }



    }
}
