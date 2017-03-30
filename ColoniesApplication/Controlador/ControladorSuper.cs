using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controlador
{
    public class ControladorSuper
    {
        ColoniesBD bd;
        public ControladorSuper(ColoniesBD bd) {
            this.bd = bd;
        }
        public List<Personal> listarTodos() {
            return bd.listarTodos();
        }
        public bool insertarAdmin(Personal p, String numSS) {
            return true;
        }
        public bool modificarAdmin(Personal p, String numSS) {
            return true;
        }
        public bool insertarMonitor(Personal p, String nacimiento) {
            return true;
        }
        public bool borrarMonitor(Personal p, String nacimiento){
            return true;
        }
        public bool insertatActividadCasa(String idActivitad, String idCasa, int nivel) {
            return true;
        }

    }
}
