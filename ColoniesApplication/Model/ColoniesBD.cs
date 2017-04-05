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
        public Personal login(String user, String password)
        {
            Personal p = null;
            bool b = false;
            MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
            sqlCon.Open();
            String query = "Select * from personal Where DNI like '" + user + "'";
            MySqlCommand mysqlCmd = new MySqlCommand(query, sqlCon);
            MySqlDataReader sqlReader = mysqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                p = new Personal((String)sqlReader.GetValue(0),
                    (String)sqlReader.GetValue(1),
                    (String)sqlReader.GetValue(2),
                    (String)sqlReader.GetValue(3),
                    (String)sqlReader.GetValue(4));
            }
            if (!(password == p.getEmail()))
            {
                p = null;
            }else {
                p = getRole(p);

            }
            return p;
        }

        private Personal getRole(Personal p)
        {
            Personal r = null;
            MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
            sqlCon.Open();
            String query = "Select * from Administrador Where DNI like '" + p.getDNI() + "'";
            MySqlCommand mysqlCmd = new MySqlCommand(query, sqlCon);
            MySqlDataReader sqlReader = mysqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                r = new Administrador(p.getDNI(),
                    p.getName(),
                    p.getLastName(),
                    p.getPhone(),
                    p.getEmail(), (int)sqlReader.GetValue(1), (String)sqlReader.GetValue(2));
            }
            query = "Select * from Monitor Where DNI like '" + p.getDNI() + "'";
            mysqlCmd = new MySqlCommand(query, sqlCon);
            sqlReader = mysqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                r = new Monitor(p.getDNI(),
                    p.getName(),
                    p.getLastName(),
                    p.getPhone(),
                    p.getEmail(), (DateTime)sqlReader.GetValue(1));
            }
            return r;
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
                String query1 = "INSERT INTO personal VALUES (" + p.getDNI() + "," + p.getName() + "," + p.getLastName() + "," + p.getPhone() + "," + p.getEmail() + ")";
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();

                //insertar administrador (p.dni, numSS, p.role)
                String query2 = "INSERT INTO administrador VALUES (" + p.getDNI() + "," + numSS + "," + p.getRole()+")";
                MySqlCommand mysqlCmd2 = new MySqlCommand(query2, sqlCon);
                MySqlDataReader sqlReader2 = mysqlCmd2.ExecuteReader();

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

