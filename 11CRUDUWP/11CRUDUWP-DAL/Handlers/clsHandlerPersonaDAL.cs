using _11CRUDUWP_DAL.Connection;
using _11CRUDUWP_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11CRUDUWP_DAL.Handlers
{
    public class clsHandlerPersonaDAL
    {
        /// <summary>
        /// Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y eliminar la persona correspondiente 
        /// con el id recibido por paramentros
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public int deletePersonaDAL(int ID)
        {

            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "DELETE FROM Personas WHERE ID=" + ID;
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
        /// Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y actualiza el registro de la persona 
        /// recibida por parametros
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int updatePersonaDAL(clsPersona persona)
        {

            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "UPDATE Personas SET Nombre=@nombre, Apellidos=@apellidos, Direccion=@direccion, FechaNacimiento=@fechanacimiento, Telefono=@tlf, IDDepartamento=@iddepartamento WHERE ID=@id";

                query.Parameters.AddWithValue("id", persona.Id);
                query.Parameters.AddWithValue("nombre", persona.Nombre);
                query.Parameters.AddWithValue("apellidos", persona.Apellidos);
                query.Parameters.AddWithValue("direccion", persona.Direccion);
                query.Parameters.AddWithValue("fechanacimiento", persona.FechaNacimiento);
                query.Parameters.AddWithValue("tlf", persona.Telefono);
                query.Parameters.AddWithValue("iddepartamento", persona.IdDepartamento);

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
        /// los datos de la persona recibida por parametros
        /// </summary>
        /// <param name="persona"></param>
        /// <returns></returns>
        public int createPersonaDAL(clsPersona persona)
        {

            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "INSERT INTO Personas (Nombre, Apellidos, Direccion, FechaNacimiento, Telefono, IDDepartamento) " +
                    "VALUES(@nombre, @apellidos, @direccion, @fechanacimiento, @tlf, @iddepartamento )";

                query.Parameters.AddWithValue("nombre", persona.Nombre);
                query.Parameters.AddWithValue("apellidos", persona.Apellidos);
                query.Parameters.AddWithValue("direccion", persona.Direccion);
                query.Parameters.AddWithValue("fechanacimiento", persona.FechaNacimiento);
                query.Parameters.AddWithValue("tlf", persona.Telefono);
                query.Parameters.AddWithValue("iddepartamento", persona.IdDepartamento);

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