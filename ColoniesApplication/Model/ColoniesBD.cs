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
            List<Personal> lista = new List<Personal>();
            Personal p = null;
            bool b = false;
            MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
            sqlCon.Open();
            String query = "Select p.*, a.titulacion from personal p, administrador a Where p.DNI=a.DNI AND p.DNI";
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

                lista.Add(p);
            }            

            return lista;
        }

        public bool insertarAdmin(Personal p, String numSS)
        {
            //insertar en la tabla "personal" el objeto p y en la tabla "administrador" el 
            //numSS y la titulacion("admin" en este caso)
            Boolean flag=false;            
            bool b = false;
            try
            {                                
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query = "Select p.*, a.titulacion from personal p, administrador a Where p.DNI=a.DNI AND p.DNI";
                MySqlCommand mysqlCmd = new MySqlCommand(query, sqlCon);
                MySqlDataReader sqlReader = mysqlCmd.ExecuteReader();
                flag = true;
            }
            catch (MySqlException)
            {
                flag = false;
            }
            return flag;
        }


    }
    }

