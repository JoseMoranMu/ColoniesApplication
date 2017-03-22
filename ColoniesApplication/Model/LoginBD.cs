using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Model
{
    class LoginBD
    {
        public static bool login(String user, String password)
        {
            String p ="";
            bool b = false;
            MySqlConnection sqlCon = new MySqlConnection("Server= localhost; Database= colonies;Uid=root;Pwd=;");
            sqlCon.Open();
            String query = "Select email from personal Where DNI="+user;
            MySqlCommand mysqlCmd = new MySqlCommand(query, sqlCon);
            MySqlDataReader sqlReader = mysqlCmd.ExecuteReader();
            while (sqlReader.Read())
            {
                p=(String)sqlReader.GetValue(0);
            }
            if (password == p) b = true;
            else b = false;
            return b;
        }
    }
}
