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
        public bool registarTascaTanda() {
            return true;
        }
    }
}
