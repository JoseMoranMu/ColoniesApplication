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
    }
}
