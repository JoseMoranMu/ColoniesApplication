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
        public bool insertarAdmin(Administrador a) {
            return bd.insertarAdmin(a);
        }
        public bool modificarAdmin(Administrador a) {
            return bd.modificarAdmin(a);
        }
        public bool insertarMonitor(Monitor m) {
            return bd.insertarMonitor(m);
        }
        public bool borrarMonitor(Monitor m){
            return bd.borrarMonitor(m);
        }
        public bool insertarActividadCasa(String idActivitad, String idCasa, int nivel) {
            return true/*insertarActividadCasa(*/;
        }
    }
}
