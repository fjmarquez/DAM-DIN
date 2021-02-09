using _11CRUDUWP_DAL.Connection;
using _11CRUDUWP_Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11CRUDUWP_DAL.Listados
{
    public class clsListadoPersonasDAL
    {

        /// <summary>
        ///  Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y obtiene un listado con la informacion de 
        ///  todas las personas de la BD
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> getListadoPersonas()
        {
            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            List<clsPersona> list = new List<clsPersona>();
            clsPersona persona;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT ID, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, IDDepartamento, Foto FROM Personas";
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        persona = new clsPersona();

                        persona.Id = (int)reader["ID"];
                        persona.Nombre = (string)reader["Nombre"];
                        if (reader["Apellidos"] != System.DBNull.Value)
                        {
                            persona.Apellidos = (string)reader["Apellidos"];
                        }
                        if (reader["FechaNacimiento"] != System.DBNull.Value)
                        {
                            persona.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        }
                        if (reader["Foto"] != System.DBNull.Value)
                        {
                            persona.Foto = (byte[])reader["Foto"];
                        }
                        if (reader["Direccion"] != System.DBNull.Value)
                        {
                            persona.Direccion = (string)reader["Direccion"];
                        }
                        if (reader["Telefono"] != System.DBNull.Value)
                        {
                            persona.Telefono = (string)reader["Telefono"];
                        }
                        if (reader["IDDepartamento"] != System.DBNull.Value)
                        {
                            persona.IdDepartamento = (int)reader["IDDepartamento"];
                        }
                        list.Add(persona);
                    }
                }
                reader.Close();
                con.closeConnection(ref sqlc);
            }
            catch (SqlException e)
            {
                list = null;
            }
            return list;
        }

        /// <summary>
        ///  Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y obtiene un listado con la informacion de 
        ///  todas las personas de la BD filtradas por nombre
        /// </summary>
        /// <returns></returns>
        public List<clsPersona> getListadoPersonasFiltradasPorNombreYApellidos(string toFilter)
        {
            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            List<clsPersona> list = new List<clsPersona>();
            clsPersona persona;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT ID, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, IDDepartamento, Foto FROM Personas WHERE Nombre LIKE '%"+toFilter+"%' OR Apellidos LIKE '%"+toFilter+"%'";
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        persona = new clsPersona();

                        persona.Id = (int)reader["ID"];
                        persona.Nombre = (string)reader["Nombre"];
                        if (reader["Apellidos"] != System.DBNull.Value)
                        {
                            persona.Apellidos = (string)reader["Apellidos"];
                        }
                        if (reader["FechaNacimiento"] != System.DBNull.Value)
                        {
                            persona.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        }
                        if (reader["Foto"] != System.DBNull.Value)
                        {
                            persona.Foto = (byte[])reader["Foto"];
                        }
                        if (reader["Direccion"] != System.DBNull.Value)
                        {
                            persona.Direccion = (string)reader["Direccion"];
                        }
                        if (reader["Telefono"] != System.DBNull.Value)
                        {
                            persona.Telefono = (string)reader["Telefono"];
                        }
                        if (reader["IDDepartamento"] != System.DBNull.Value)
                        {
                            persona.IdDepartamento = (int)reader["IDDepartamento"];
                        }
                        list.Add(persona);
                    }
                }
                reader.Close();
                con.closeConnection(ref sqlc);
            }
            catch (SqlException e)
            {
                list = null;
            }
            return list;

        }

        /// <summary>
        /// Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y obtiene el numero de personas pertenecientes a un departamento
        /// </summary>
        /// <param name="idDepartamento"></param>
        /// <returns></returns>
        public int getPersonasPorDepartamento(int idDepartamento)
        {

            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            int fieldCount = 0;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT ID FROM Personas WHERE IDDepartamento=@dpto";
                query.Parameters.AddWithValue("dpto", idDepartamento);

                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        fieldCount++;
                    }
                }


                reader.Close();
                con.closeConnection(ref sqlc);
            }
            catch (SqlException e)
            {
                throw e;
            }
            return fieldCount;

        }


        /// <summary>
        ///  Funcion de la capa DAL, la cual accede directamente a la informacion de la BD Azure y obtiene toda la informacion relacionada
        ///  con la persona cuyo id coincida con el recibido por parametros
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public clsPersona getPersonaPorID(int ID)
        {
            clsMyConnectionDAL con = new clsMyConnectionDAL();
            SqlCommand query = new SqlCommand();
            SqlDataReader reader;
            clsPersona persona = new clsPersona(); ;

            try
            {
                SqlConnection sqlc = con.getConnection();
                query.CommandText = "SELECT ID, Nombre, Apellidos, FechaNacimiento, Direccion, Telefono, IDDepartamento, Foto FROM Personas WHERE ID=" + ID;
                query.Connection = sqlc;
                reader = query.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        persona.Id = (int)reader["ID"];
                        persona.Nombre = (string)reader["Nombre"];
                        if (reader["Apellidos"] != System.DBNull.Value)
                        {
                            persona.Apellidos = (string)reader["Apellidos"];
                        }
                        if (reader["FechaNacimiento"] != System.DBNull.Value)
                        {
                            persona.FechaNacimiento = (DateTime)reader["FechaNacimiento"];
                        }
                        if (reader["Foto"] != System.DBNull.Value)
                        {
                            persona.Foto = (byte[])reader["Foto"];
                        }
                        if (reader["Direccion"] != System.DBNull.Value)
                        {
                            persona.Direccion = (string)reader["Direccion"];
                        }
                        if (reader["Telefono"] != System.DBNull.Value)
                        {
                            persona.Telefono = (string)reader["Telefono"];
                        }
                        if (reader["IDDepartamento"] != System.DBNull.Value)
                        {
                            persona.IdDepartamento = (int)reader["IDDepartamento"];
                        }
                    }
                }
                reader.Close();
                con.closeConnection(ref sqlc);
            }
            catch (SqlException e)
            {
                persona = null;
            }


            return persona;
        }



    }
}