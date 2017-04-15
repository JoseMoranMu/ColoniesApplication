using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Administrador : Personal
    {
        int nSS;
        String titulacion;
        public Administrador(string DNI, string name, string lastName, string phone, string email, int nSS, string titulacion) : base(DNI, name, lastName, phone, email)
        {
            this.nSS = nSS;
            this.titulacion = titulacion;
        }
        public int getNSS() {
            return nSS;
        }
        public void setNSS(int nSS) {
            this.nSS = nSS;
        }
        public string getTitulacion()
        {
            return titulacion;
        }
        public void setTitulacion(string titulacion)
        {
            this.titulacion = titulacion;
        }
    }
}
