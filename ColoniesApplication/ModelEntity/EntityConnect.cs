using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelEntity
{
    public class EntityConnect
    {
        coloniesEntities col;
        public EntityConnect() {
            col = new coloniesEntities();         
        }


        public List<String> selectDniMonitor() {

            List<String> lista = new List<String>();
            var dniMonitor = from monitor in col.monitor
                           select monitor;
            Console.WriteLine("Entra");
            foreach (monitor u in dniMonitor)
            {
                String s = (String)u.DNI;
                Console.WriteLine(u.DNI);
                lista.Add(s);
                    
                

            }
            return lista;
        }

        public bool registrarTascaTanda(string dNI_monitor, string codigo_tarea, string fecha_inicio_tanda, DateTime dia_tarea)
        {
            bool b = true;
            try
            {
                monitor_tareas_tandas insert = new monitor_tareas_tandas();
                insert.DNI_monitor = dNI_monitor;
                insert.codigo_tarea = codigo_tarea;
                DateTime fecha = Convert.ToDateTime(fecha_inicio_tanda);

                insert.fecha_inicio_tanda = fecha;
                insert.dia_tarea = dia_tarea;
                col.monitor_tareas_tandas.Add(insert);
                col.SaveChanges();
            }
            catch (Exception e) {
                b = false;

            }
            return b;
        }
    }
}
