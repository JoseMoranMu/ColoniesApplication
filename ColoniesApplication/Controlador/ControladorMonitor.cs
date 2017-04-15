using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controlador
{
    public class ControladorMonitor
    {
        ColoniesBD bd;
        public ControladorMonitor()
        {            
            bd = new ColoniesBD();
        }
        public bool registarTascaTanda(string DNI_monitor, string código_tarea, String fecha_inicio_tanda, String dia_tarea) {
            return bd.registrarTascaTanda (DNI_monitor, código_tarea, fecha_inicio_tanda, dia_tarea);
        }        
    }
}
