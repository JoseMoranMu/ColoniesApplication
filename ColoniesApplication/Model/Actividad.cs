using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Actividad
    {
        String codigo;
        String descripcion;

        public Actividad()
        {
        }

        public Actividad(String codigo, String descripcion)
        {
            this.codigo = codigo;
            this.descripcion = descripcion;
        }

        public String getCodigo()
        {
            return codigo;
        }

        public void setCodigo(String codigo)
        {
            this.codigo = codigo;
        }

        public String getDescripcion()
        {
            return descripcion;
        }

        public void setDescripcion(String descripcion)
        {
            this.descripcion = descripcion;
        }
    }
}
