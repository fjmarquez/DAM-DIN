using ExamenDINGrupo2DAL.Connection;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDINGrupo2DAL.HandlersDAL
{
    public class clsHandlersClientesDAL
    {

        public int updateSaldoDAL(Double retirada, int id)
        {

            clsConnection con = new clsConnection();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            int state;

            try
            {

                SqlConnection sqlc = con.getConnection();
                query.CommandText = "UPDATE CLIENTES SET SALDO = (SALDO - @retirada) WHERE ID = @id";
                query.Parameters.AddWithValue("retirada", retirada);
                query.Parameters.AddWithValue("id", id);
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                reader.Close();
                con.closeConnection(ref sqlc);

                state = reader.RecordsAffected;


            }
            catch
            {

                state = 0;

            }

            return state;

        }

    }
}
