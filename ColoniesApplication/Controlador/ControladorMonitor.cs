using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ModelEntity;

namespace Controlador
{
    public class ControladorMonitor
    {
        EntityConnect bd;
        public ControladorMonitor()
        {            
            bd = new EntityConnect();
        }
        public List<String> selectDniMonitor() {
            return bd.selectDniMonitor();
        }
        public bool registarTascaTanda(string DNI_monitor, string codigo_tarea, string fecha_inicio_tanda, DateTime dia_tarea) {
            return bd.registrarTascaTanda (DNI_monitor, codigo_tarea, fecha_inicio_tanda, dia_tarea);
  
        }        
    }
}
