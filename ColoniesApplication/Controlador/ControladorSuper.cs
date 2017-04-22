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
        public ControladorSuper() {
            bd = new ColoniesBD();
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
        public bool borrarMonitor(String dni){
            return bd.borrarMonitor(dni);
        }
        public bool insertarActividadCasa(Actividad a, String casa, int nivel) {
            return bd.insertarActividadCasa(a,casa,nivel);
        }
        public List<String> getDNIAdmin() {
            return bd.getDNIAdmin();
        }

        public List<String> getDNIMoni()
        {
            return bd.getDNIMoni();
        }
    }
}
