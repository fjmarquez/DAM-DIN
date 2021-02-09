using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolaMundoUWPCSharp
{
    class persona
    {
        //Atributos

        private String nombre;


        //Propiedades

        public String Nombre {

            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        
        }

        //Constructor

        public persona()
        {

        }

        public persona(String n)
        {
            this.Nombre = n;
        }


    }
}
