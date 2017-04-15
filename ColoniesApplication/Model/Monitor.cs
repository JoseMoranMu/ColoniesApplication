using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Monitor : Personal
    {
        DateTime fechaNacimiento;
        
        public Monitor(string DNI, string name, string lastName, string phone, string email, DateTime fechaNacimiento) : base(DNI, name, lastName, phone, email)
        {
            this.fechaNacimiento = fechaNacimiento;
        }
        public DateTime getFechaNacimiento()
        {
            return fechaNacimiento;
        }
        public void setFechaNacimiento(DateTime fechaNacimiento)
        {
            this.fechaNacimiento = fechaNacimiento;
        }
    }
}
