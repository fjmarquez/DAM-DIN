using ExamenDINGrupo2DAL.HandlersDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDINGrupo2BL.HandlersBL
{
    public class clsHandlersClientesBL
    {

        public int updateSaldoBL(Double retirada, int id)
        {
            return new clsHandlersClientesDAL().updateSaldoDAL(retirada, id);
        }
    }
}
