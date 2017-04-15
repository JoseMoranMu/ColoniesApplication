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
            if (p != null)
            {
                if (!(password == p.getEmail()))
                {
                    p = null;
                }
                else
                {
                    p = getRole(p);

                }
                sqlCon.Close();
                sqlReader.Close();
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
            sqlReader.Close();
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
            Boolean flag = false;
            bool b = false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();

                //insertar personal (dni, nombre, apellidos, teléfono, email)
                String query1 = "INSERT INTO personal VALUES ('" + a.getDNI() + "','" + a.getName() + "','" + a.getLastName() + "','" + a.getPhone() + "','" + a.getEmail() + "')";
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                sqlReader1.Close();

                //insertar administrador (p.dni, numSS, p.role)
                String query2 = "INSERT INTO administrador VALUES ('" + a.getDNI() + "'," + a.getNSS() + ",'" + a.getTitulacion() + "')";
                MySqlCommand mysqlCmd2 = new MySqlCommand(query2, sqlCon);
                MySqlDataReader sqlReader2 = mysqlCmd2.ExecuteReader();

                sqlReader2.Close();
                flag = true;
                sqlCon.Close();
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
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
                String query1 = "UPDATE personal SET nombre='" + a.getName() + "', apellidos='" + a.getLastName() + "', teléfono='" + a.getPhone() + "', email='" + a.getEmail() + "' WHERE DNI= '" + a.getDNI() + "'"/*+ ";"*/;
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                sqlReader1.Close();

                //update tabla administrador
                String query2 = "UPDATE administrador SET num_SS=" + a.getNSS() + ", titulacion='" + a.getTitulacion() + "' WHERE DNI='" + a.getDNI() + "'" /*+ ";"*/;
                MySqlCommand mysqlCmd2 = new MySqlCommand(query2, sqlCon);
                MySqlDataReader sqlReader2 = mysqlCmd2.ExecuteReader();


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

        public bool borrarMonitor(String dni)
        {
            Boolean flag = false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query1 = "DELETE FROM monitor WHERE DNI='" + dni +"'"/*+ ";"*/;
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                sqlReader1.Close();

                String query2 = "DELETE FROM personal WHERE DNI='" + dni + "'"/*+ ";"*/;
                MySqlCommand mysqlCmd2 = new MySqlCommand(query2, sqlCon);
                MySqlDataReader sqlReader2 = mysqlCmd2.ExecuteReader();
                sqlReader2.Close();
                flag = true;                
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
                String query0 = "INSERT INTO personal VALUES ('" + m.getDNI() + "','" + m.getName() + "','" + m.getLastName() + "','" + m.getPhone() + "','" + m.getEmail() + "')";

                MySqlCommand mysqlCmd0 = new MySqlCommand(query0, sqlCon);
                MySqlDataReader sqlReader0 = mysqlCmd0.ExecuteReader();
                sqlReader0.Close();
                Console.WriteLine(m.getFechaNacimiento().Date.ToString("yyyy-MM-dd"));
                String query1 = "INSERT INTO monitor VALUES ('" + m.getDNI() + "', '" + m.getFechaNacimiento().Date.ToString("yyyy-MM-dd") + "')";
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                flag = true;
                sqlReader1.Close();
                sqlCon.Close();
            }
            catch (MySqlException e)
            {
                Console.Write(e.Message);
                flag = false;
            }

            return flag;
        }

        public bool insertarActividadCasa(Actividad a, String casa, int nivel)
        {

            Boolean flag = false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query1 = "INSERT INTO actividad VALUES ('" + a.getCodigo() + "', '" + a.getDescripcion() + "')"/*+ ";"*/;
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                sqlReader1.Close();

                String query2 = "INSERT INTO actividad_casa VALUES ('" + a.getCodigo() + "', '" + casa + "',"+nivel+")"/*+ ";"*/;
                MySqlCommand mysqlCmd2 = new MySqlCommand(query2, sqlCon);
                MySqlDataReader sqlReader2 = mysqlCmd2.ExecuteReader();
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

        /// <summary>
        /// METODOS CONTROLADOR ADMIN //////
        /// </summary>
        /// <param name="carnet_ninio"></param>
        /// <param name="fecha_inicio"></param>
        /// <param name="nombre_casa"></param>
        /// <param name="numero_inscripcion"></param>
        /// <returns></returns>
        public bool modificarInscripcion(int carnet_ninio, String fecha_inicio, string nombre_casa, int numero_inscripcion)
        {

            Boolean flag = false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query1 = "UPDATE INSCRIPCIONES_TANDA_CASA SET  nombre_casa='" + nombre_casa + "', numero_inscripcion=" + numero_inscripcion + " WHERE carnet_niño='" + carnet_ninio + "' AND fecha_inicio='" + fecha_inicio + "'" /*+ ";"*/;
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();

                sqlReader1.Close();
                flag = true;
                sqlCon.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                flag = false;
            }

            return flag;
        }

        public bool insertarInscripcion(int carnet_ninio, String fecha_inicio, string nombre_casa, int numero_inscripcion)
        {
            Boolean flag = false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query1 = "INSERT INTO INSCRIPCIONES_TANDA_CASA VALUES (" + carnet_ninio + ", '" + fecha_inicio + "', '" + nombre_casa + "', " + numero_inscripcion + ")"/*+ ";"*/;
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
                flag = true;
                sqlReader1.Close();
                sqlCon.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                flag = false;
            }
            return flag;
        }        
    

        public bool modificarNen(Ninio n, string codpoblacion)
        {
            Boolean flag = false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query1 = "UPDATE nino SET nombre='" + n.getNombre() + "', apellidos='" + n.getApellidos() + "', direccion='" + n.getDireccion() + "', sexo='" + n.getSexo() + "', anio_nacimiento=" + n.getAnio_nacimiento() + ", codigo_poblacion='" + codpoblacion + "' WHERE carnet=" + n.getCarnet() /*+ ";"*/;
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
                MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();

                sqlReader1.Close();                
                flag = true;
                sqlCon.Close();
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                flag = false;
            }

            return flag;            
        }

        public bool insertatNens(Ninio n, string codpoblacion)
        {
            Boolean flag = false;
            try {            
            MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
            sqlCon.Open();
            String query1 = "INSERT INTO nino VALUES (" + n.getCarnet() + ", '" + n.getNombre() + "', '" + n.getApellidos() + "', '" + n.getDireccion() + "', '" + n.getSexo() + "', " + n.getAnio_nacimiento() + ", '" + codpoblacion + "')"/*+ ";"*/;
                MySqlCommand mysqlCmd1 = new MySqlCommand(query1, sqlCon);
            MySqlDataReader sqlReader1 = mysqlCmd1.ExecuteReader();
            flag = true;
            sqlReader1.Close();
            sqlCon.Close();
        }catch (MySqlException e){
                flag =false;
        }
            return flag;
        }

        /// <summary>
        /// METODOS CONTROLADOR ADMIN //////
        /// </summary>
        /// <param name="dNI_monitor"></param>
        /// <param name="código_tarea"></param>
        /// <param name="fecha_inicio_tanda"></param>
        /// <param name="dia_tarea"></param>
        /// <returns></returns>
        public bool registrarTascaTanda(string dNI_monitor, string código_tarea, String fecha_inicio_tanda, String dia_tarea)
        {
            Console.WriteLine("entra");
            Boolean flag = false;
            
            
            /*
            
            var list = (from a in db.personal
                        select new (dni=a.DNI));
            foreach (var r in list) {
                Console.WriteLine(r.ToString());

            }*/
                /*
                
                Boolean flag = false;
            try
            {
                MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=alumne;Pwd=alumne;");
                sqlCon.Open();
                String query1 = "INSERT INTO MONITOR_TAREAS_TANDAS  VALUES ('" + dNI_monitor + "', '" + código_tarea + "', " + fecha_inicio_tanda + ", " + dia_tarea + "')";
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
            */
            return flag;
        }
    }
}

