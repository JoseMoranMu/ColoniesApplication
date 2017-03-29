using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Personal
    {
        private String DNI;
        private String name;
        private String lastName;
        private String phone;
        private String email;
        private String role;
        public Personal(String DNI, String name, String lastName, String phone, String email, String role) {
            this.DNI = DNI;
            this.name = name;
            this.lastName = lastName;
            this.phone = phone;
            this.email = email;
            this.role = role;
        }
        public String getDNI()
        {
            return DNI;
        }

        public String getName()
        {
            return name;
        }

        public String getLastName()
        {
            return lastName;
        }

        public String getPhone()
        {
            return phone;
        }

        public String getEmail()
        {
            return email;
        }
        public String getRole()
        {
            return role;
        }

        public void setDNI(String DNI)
        {
            this.DNI = DNI;
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public void setLastName(String lastName)
        {
            this.lastName = lastName;
        }

        public void setPhone(String phone)
        {
            this.phone = phone;
        }

        public void setEmail(String email)
        {
            this.email = email;
        }
        public void setRole(String role) {
            this.role = role;
        }
    }
}
