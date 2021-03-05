using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2TrimestreEntities
{
    public class aula
    {

        private int id;
        private string nombre;

        public int Id
        { 
        
            get
            {
                return id;
            }

            set
            {
                this.id = value;
            }
 
        }


        public string Nombre
        {

            get
            {

                return this.nombre;

            }

            set
            {

                this.nombre = value;

            }

        }

    }
}
