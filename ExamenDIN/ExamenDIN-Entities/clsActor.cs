using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDIN_Entities
{
    public class clsActor
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
                return nombre;
            }
            set
            {
                this.nombre = value;
            }
        }


        public clsActor()
        {
            this.id = 0;
            this.nombre = "";
        }

        public clsActor(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public clsActor (clsActor actor)
        {
            this.id = actor.id;
            this.nombre = actor.nombre;
        }

    }
}
