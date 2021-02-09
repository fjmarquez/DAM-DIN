using ExamenDINGrupo2DAL.Connection;
using ExamenDINGrupo2Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenDINGrupo2DAL.ListadosDAL
{
    public class clsListadosClientesDAL
    {

        /// <summary>
        /// Esta funcion de la capa DAL recibe un pin y comprueba que exista un cliente con dicho pin, 
        /// si existe se devolvera todos los datos de ese cliente en un objeto de tipo clsCliente
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public clsCliente getClientePorPinDAL (string pin)
        {

            clsConnection con = new clsConnection();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            clsCliente cliente = new clsCliente();

            try
            {

                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT ID, SALDO, NOMBRE, PIN FROM CLIENTES WHERE PIN=@pin";
                query.Parameters.AddWithValue("pin", pin);
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {

                    cliente.Id = (int)reader["ID"];
                    cliente.Saldo = (Double)reader["SALDO"];
                    cliente.Nombre = (String)reader["NOMBRE"];
                    cliente.Pin = (String)reader["PIN"];

                }

                reader.Close();
                con.closeConnection(ref sqlc);
                

            }catch(SqlException e)
            {

                cliente = null;

            }


            return cliente;
        }

    }
}
