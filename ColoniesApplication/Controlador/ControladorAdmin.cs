using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controlador
{
    public class ControladorAdmin
    {
        public ColoniesBD bd;
        public ControladorAdmin()
        {
            bd = new ColoniesBD();            
        }
        
        public bool insertatNens(Ninio n) {
            return bd.insertatNens(n);
        }
        public bool modificarNen(Ninio n) {
            return bd.modificarNen(n);
        }
        public bool insertarInscripcion(int carnet_ninio, DateTime fecha_inicio, String nombre_casa, int numero_inscripcion) {
            return bd.insertarInscripcion(carnet_ninio, fecha_inicio, nombre_casa, numero_inscripcion);
        }
        public bool modificarInscripcion(int carnet_ninio, DateTime fecha_inicio, String nombre_casa, int numero_inscripcion)
        {
            return bd.modificarInscripcion(carnet_ninio, fecha_inicio, nombre_casa, numero_inscripcion);
        }
    }
}
