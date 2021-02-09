using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDXamarinEntities
{

    public class clsDepartamento
    {
        private int id;
        private string departamento;

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

        public string Departamento
        {
            get
            {
                return departamento;
            }
            set
            {
                departamento = value;
            }
        }

        public clsDepartamento(int id, string departamento)
        {
            this.Id = id;
            this.Departamento = departamento;
        }

        public clsDepartamento()
        {
            this.Id = 0;
            this.Departamento = "";
        }


        public clsDepartamento(clsDepartamento departamento)
        {
            this.Id = departamento.Id;
            this.Departamento = departamento.Departamento;
        }
    }

}
