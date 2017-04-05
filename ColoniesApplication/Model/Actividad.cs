using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Actividad
    {
        private String idActividad;
        private String idCasa;
        int nivel;

        public Actividad (String idActividad, String idCasa, int nivel)
        {
            this.idActividad = idActividad;
            this.idCasa = idCasa;
            this.nivel = nivel;
        }

        public string getIdActividad()
        {
            return idActividad;
        }

        //public string 

    }
}
