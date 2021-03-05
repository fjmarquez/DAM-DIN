using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examen2TrimestreEntities
{
    public class temperaturas
    {

        private int idAula;
        private DateTime fecha;
        private Double temp1;
        private Double temp2;
        private Double temp3;

        public int IdAula
        {

            get
            {

                return idAula;

            }

            set
            {
                this.idAula = value;
            }

        }

        public DateTime Fecha
        {

            get
            {

                return fecha;

            }

            set
            {

                this.fecha = value;

            }

        }

        public Double Temp1
        {

            get
            {

                return temp1;

            }

            set
            {

                this.temp1 = value;

            }

        }

        public Double Temp2
        {

            get
            {

                return temp2;

            }

            set
            {

                this.temp2 = value;

            }

        }

        public Double Temp3
        {

            get
            {

                return temp3;

            }

            set
            {

                this.temp3 = value;

            }

        }

    }
}
