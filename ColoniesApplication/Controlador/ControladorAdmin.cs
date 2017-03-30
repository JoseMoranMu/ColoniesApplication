using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Controlador
{
    class ControladorAdmin
    {
        public ColoniesBD bd;
        public ControladorAdmin(ColoniesBD bd)
        {
            this.bd = bd;
        }
        
        public bool insertatNens() {
            return true;
        }
        public bool modificarNen() {
            return true;
        }
        public bool insertarInscripcion() {
            return true;
        }
        public bool modificarInscripcion(){
            return true;
        }
    }
}
