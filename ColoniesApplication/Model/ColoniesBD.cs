using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Model
{
    public class ColoniesBD
    {
        public ColoniesBD() {
        }
        public static Personal login(String user, String password)
        {
            Personal p = null;
            bool b = false;
            MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
            sqlCon.Open();
            String query = "Select p.*, a.titulacion from personal p, administrador a Where p.DNI=a.DNI AND p.DNI like '" + user + "'";
            MySqlCommand mysqlCmd = new MySqlCommand(query, sqlCon);
            MySqlDataReader sqlReader = mysqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                p = new Personal((String)sqlReader.GetValue(0),
                    (String)sqlReader.GetValue(1),
                    (String)sqlReader.GetValue(2),
                    (String)sqlReader.GetValue(3),
                    (String)sqlReader.GetValue(4),
                    (String)sqlReader.GetValue(5));
            }
            if (!(password == p.getEmail())) p = null;
            return p;
        }

        public List<Personal> listarTodos()
        {
            List<Personal> listaTodos = new List<Personal>();
            Personal p = null;
            bool b = false;
            MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
            sqlCon.Open();
            String query = "Select * from personal ";
            MySqlCommand mysqlCmd = new MySqlCommand(query, sqlCon);
            MySqlDataReader sqlReader = mysqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                p = new Personal((String)sqlReader.GetValue(0),
                    (String)sqlReader.GetValue(1),
                    (String)sqlReader.GetValue(2),
                    (String)sqlReader.GetValue(3),
                    (String)sqlReader.GetValue(4),
                    "monitor");
                listaTodos.Add(p);
            }

            listaTodos = listarTodosRoles(listaTodos);
            sqlCon.Close();
            return listaTodos;
        }

        public List<Personal> listarTodosRoles(List<Personal> listaTodos) {            
            Personal p = null;
            String DNI;
            String titulacion;
            MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
            sqlCon.Open();
            String query = "Select DNI,titulacion from administrador";
            MySqlCommand mysqlCmd = new MySqlCommand(query, sqlCon);
            MySqlDataReader sqlReader = mysqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                DNI = (String)sqlReader.GetValue(0);
                titulacion = (String)sqlReader.GetValue(1);
                for (int i = 0; i < listaTodos.Count; i++) {
                    if (listaTodos[i].getDNI().Equals(DNI)) {
                        listaTodos[i].setRole(titulacion);
                    }
                }
            }


            return listaTodos;
        }

        public bool insertarAdmin(Personal p, String numSS)
        {
            //insertar en la tabla "personal" el objeto p y en la tabla "administrador" el 
            //numSS y la titulacion("admin" en este caso)
            //TODO query
            Boolean flag=false;            
            bool b = false;
            try
            {                                
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                
                //insertar personal (dni, nombre, apellidos, teléfono, email)
                String query = "Select p.*, a.titulacion from personal p, administrador a Where p.DNI=a.DNI AND p.DNI";
                MySqlCommand mysqlCmd = new MySqlCommand(query, sqlCon);
                MySqlDataReader sqlReader = mysqlCmd.ExecuteReader();

                //insertar administrador (p.dni, numSS, p.role)
                /*String query = "Select p.*, a.titulacion from personal p, administrador a Where p.DNI=a.DNI AND p.DNI";
                MySqlCommand mysqlCmd = new MySqlCommand(query, sqlCon);
                MySqlDataReader sqlReader = mysqlCmd.ExecuteReader();*/

                flag = true;
                sqlCon.Close();
            }
            catch (MySqlException)
            {
                flag = false;
            }            
            return flag;
        }


    }
    }

