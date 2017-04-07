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
            sqlCon.Close();
            sqlReader.Close();
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
            sqlCon.Close();
            sqlReader.Close();
            return r;
        }

        /// <summary>
        /// METODOS CONTROLADOR SUPER
        /// </summary>
        /// <returns></returns>
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
                    (String)sqlReader.GetValue(4));
                p = getRole(p);
                listaTodos.Add(p);
            }
            sqlCon.Close();
            sqlReader.Close();
            return listaTodos;
        }

        public bool insertarAdmin(Administrador a)
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
                String query1 = "INSERT INTO personal VALUES (" + a.getDNI() + "," + a.getName() + "," + a.getLastName() + "," + a.getPhone() + "," + a.getEmail() + ")";
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();

                //insertar administrador (p.dni, numSS, p.role)
                String query2 = "INSERT INTO administrador VALUES (" + a.getDNI() + "," + a.getNSS() + "," + a.getTitulacion()+")";
                MySqlCommand mysqlCmd2 = new MySqlCommand(query2, sqlCon);
                MySqlDataReader sqlReader2 = mysqlCmd2.ExecuteReader();

                sqlReader1.Close();
                sqlReader2.Close();
                flag = true;
                sqlCon.Close();
            }
            catch (MySqlException)
            {
                flag = false;
            }            
            return flag;
        }

        public bool modificarAdmin(Administrador a)
        {
            Boolean flag = false;
            try
            {
                //udpate tabla personal
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query1 = "UPDATE personal SET nombre=" + a.getName() + ", apellidos=" + a.getLastName() + ", teléfono=" + a.getPhone() + ", email=" + a.getEmail() + "WHERE DNI=" + a.getDNI() /*+ ";"*/;
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                
                //update tabla administrador
                String query2 = "UPDATE administrador SET num_SS=" + a.getNSS() + ", titulacion=" + a.getTitulacion() + "WHERE DNI=" + a.getDNI() /*+ ";"*/;
                MySqlCommand mysqlCmd2 = new MySqlCommand(query2, sqlCon);
                MySqlDataReader sqlReader2 = mysqlCmd2.ExecuteReader();

                sqlReader1.Close();
                sqlReader2.Close();
                flag = true;
                sqlCon.Close();
            }
            catch (MySqlException)
            {
                flag = false;
            }

            return flag;
        }

        public bool borrarMonitor(String  dni)
        {
            Boolean flag=false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query1 = "DELETE FROM monitor WHERE DNI=" + dni /*+ ";"*/;
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                flag = true;
                sqlReader1.Close();
                sqlCon.Close();
            }
            catch (MySqlException) {
                flag = false;
            }            
            return flag;
        }

        public bool insertarMonitor(Monitor m)
        {
            Boolean flag = false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open(); 
                 String query1 = "INSERT INTO monitor VALUES (" + m.getDNI() + ", "+ m.getFechaNacimiento() + ")";
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                flag = true;
                sqlReader1.Close();
                sqlCon.Close();
            }
            catch (MySqlException)
            {
                flag = false;
            }

            return flag;
        }

        public bool insertarActividadCasa(Actividad a, String casa, int nivel)
        {
            /**
             * JOSE:
             * Aparte de añadir actividad en la tabla actividad es 
             * necesario añadir tmb la actividad en la tabla actividad_casa
             * por lo que este metodo tmb pillara por parametro, 
             * el codigo de casa (String)
             * y el nivel que tiene (int)
             * para que se pueda añadir a esa tabla
             * te dejo preparado los parametros en la funcion
             * */
            Boolean flag = false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query1 = "INSERT INTO actividad VALUES (" + a.getCodigo() + ", " + a.getDescripcion() + ")";
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                flag = true;
                sqlReader1.Close();
                sqlCon.Close();
            }
            catch (MySqlException)
            {
                flag = false;
            }

            return flag;
        }

        /// <summary>
        /// METODOS CONTROLADOR ADMIN
        /// </summary>
        /// <param name="carnet_ninio"></param>
        /// <param name="fecha_inicio"></param>
        /// <param name="nombre_casa"></param>
        /// <param name="numero_inscripcion"></param>
        /// <returns></returns>
        public bool modificarInscripcion(int carnet_ninio, DateTime fecha_inicio, string nombre_casa, int numero_inscripcion)
        {
            throw new NotImplementedException();
        }

        public bool insertarInscripcion(int carnet_ninio, DateTime fecha_inicio, string nombre_casa, int numero_inscripcion)
        {
            throw new NotImplementedException();
        }

        public bool modificarNen(Ninio n)
        {
            throw new NotImplementedException();
        }

        public bool insertatNens(Ninio n)
        {
            throw new NotImplementedException();
        }


    }
}

