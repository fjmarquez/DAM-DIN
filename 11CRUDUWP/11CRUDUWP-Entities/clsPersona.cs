using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11CRUDUWP_Entities
{
    public class clsPersona
    {
        private int id;
        private byte[] foto;
        private String nombre, apellidos, direccion, telefono;
        private DateTime fechaNacimiento;
        private int idDepartamento;



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

        public byte[] Foto
        {
            get
            {
                return foto;
            }
            set
            {
                foto = value;
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
                nombre = value;
            }
        }
        public string Apellidos
        {
            get
            {
                return apellidos;
            }
            set
            {
                apellidos = value;
            }
        }
        public DateTime FechaNacimiento
        {
            get
            {
                return fechaNacimiento;
            }
            set
            {
                fechaNacimiento = value;
            }
        }

        public string Direccion
        {
            get
            {
                return direccion;
            }
            set
            {
                direccion = value;
            }
        }

        public string Telefono
        {
            get
            {
                return telefono;
            }
            set
            {
                telefono = value;
            }
        }

        public int IdDepartamento
        {
            get
            {
                return idDepartamento;
            }
            set
            {
                idDepartamento = value;
            }
        }

        public clsPersona(String nombre, String apellidos, DateTime fechaNacimiento, string direccion, string telefono, int idDepartamento, byte[] foto)
        {

            this.Nombre = nombre;
            this.Apellidos = apellidos;
            this.FechaNacimiento = fechaNacimiento;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.IdDepartamento = idDepartamento;
            this.foto = foto;
        }

        public clsPersona()
        {

            this.Nombre = "";
            this.Apellidos = "";
            this.FechaNacimiento = DateTime.Now;
            this.Direccion = "";
            this.Telefono = "";
            this.IdDepartamento = 1;
            this.foto = null;
        }

        public clsPersona(clsPersona persona)
        {

            this.Nombre = persona.nombre;
            this.Apellidos = persona.apellidos;
            this.FechaNacimiento = persona.fechaNacimiento;
            this.Direccion = persona.direccion;
            this.Telefono = persona.telefono;
            this.IdDepartamento =persona.idDepartamento;
            this.foto = persona.foto;
        }

    }
}
