using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controlador
{
    class ControladorMonitor
    {
        ColoniesBD bd;
        public ControladorMonitor(ColoniesBD bd)
        {
            this.bd = bd;
        }
        public bool registarTascaTanda() {
            return true;
        }
    }
}
