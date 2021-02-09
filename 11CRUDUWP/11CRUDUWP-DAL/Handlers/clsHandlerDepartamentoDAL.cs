using _11CRUDUWP_DAL.Connection;
using _11CRUDUWP_DAL.Listados;
using _11CRUDUWP_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11CRUDUWP_DAL.Handlers
{
    public class clsHandlerDepartamentoDAL
    {

        /// <summary>
        /// Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y elimina el departamento correspondiente 
        /// con el id recibido por paramentros, solo en el caso que no existan personas con dicho departamento asignado
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int deleteDepartamentosDAL(int ID)
        {

            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;

            try
            {
                int personasEnDepartamento = new clsListadoPersonasDAL().getPersonasPorDepartamento(ID);

                if (personasEnDepartamento == 0)
                {
                    SqlConnection sqlc = con.getConnection();
                    query.CommandText = "DELETE FROM Departamentos WHERE ID=" + ID;
                    query.Connection = sqlc;
                    reader = query.ExecuteReader();

                    reader.Close();
                    con.closeConnection(ref sqlc);

                    return reader.RecordsAffected;
                }
                else
                {
                    return -1;
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            
        }


        /// <summary>
        /// Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y actualiza el registro del departamento 
        /// recibido por parametros
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public int updateDepartamentoDAL(clsDepartamento departamento)
        {

            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "UPDATE Departamentos SET nombre=@nombre WHERE ID=@id";

                query.Parameters.AddWithValue("id", departamento.Id);
                query.Parameters.AddWithValue("nombre", departamento.Departamento);
                

                query.Connection = sqlc;
                reader = query.ExecuteReader();

                reader.Close();
                con.closeConnection(ref sqlc);
            }
            catch (SqlException e)
            {
                throw e;
            }
            return reader.RecordsAffected;
        }


        /// <summary>
        /// Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y inserta un nuevo registro con
        /// los datos del departamento recibido por parametros
        /// </summary>
        /// <param name="departamento"></param>
        /// <returns></returns>
        public int createDepartamentoDAL(clsDepartamento departamento)
        {

            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "INSERT INTO Departamentos (Nombre) " +
                    "VALUES(@nombre)";

                query.Parameters.AddWithValue("nombre", departamento.Departamento);

                query.Connection = sqlc;
                reader = query.ExecuteReader();

                reader.Close();
                con.closeConnection(ref sqlc);
            }
            catch (SqlException e)
            {
                throw e;
            }

            return reader.RecordsAffected;
        }


    }
}
