using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ninio
    {
        private int carnet;
        private String nombre, apellidos, direccion;
        private char sexo;
        private int anio_nacimiento;

        public Ninio(int carnet, String nombre, String apellidos, String direccion, char sexo, int anio_nacimiento)
        {
            this.carnet = carnet;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.direccion = direccion;
            this.sexo = sexo;
            this.anio_nacimiento = anio_nacimiento;
        }

        public int getCarnet()
        {
            return carnet;
        }

        public void setCarnet(int carnet)
        {
            this.carnet = carnet;
        }

        public String getNombre()
        {
            return nombre;
        }

        public void setNombre(String nombre)
        {
            this.nombre = nombre;
        }

        public String getApellidos()
        {
            return apellidos;
        }

        public void setApellidos(String apellidos)
        {
            this.apellidos = apellidos;
        }

        public String getDireccion()
        {
            return direccion;
        }

        public void setDireccion(String direccion)
        {
            this.direccion = direccion;
        }

        public char getSexo()
        {
            return sexo;
        }

        public void setSexo(char sexo)
        {
            this.sexo = sexo;
        }

        public int getAnio_nacimiento()
        {
            return anio_nacimiento;
        }

        public void setAnio_nacimiento(int anio_nacimiento)
        {
            this.anio_nacimiento = anio_nacimiento;
        }
    }
}
