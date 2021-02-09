using ExamenDINGrupo2DAL.ListadosDAL;
using ExamenDINGrupo2Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDINGrupo2BL.ListadosBL
{
    public class clsListadosClientesBL
    {

        public clsCliente getClientePorPinBL(String pin)
        {

            clsCliente cliente;

            try
            {

                cliente = new clsListadosClientesDAL().getClientePorPinDAL(pin);

            }
            catch
            {

                cliente = null;

            }
            
            return cliente;

        }

    }
}
