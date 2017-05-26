using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_Integracion.Models
{
    class DB
    {
        private static string connStr = "SERVER=localhost;DATABASE=proyecto_integracion_api;UID=proyecto_integracion_user;PASSWORD=qwer12345678";


        public static DataSet GetDataSet(MySqlCommand command)
        {
            var ds = new DataSet();
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                command.Connection = conn;
                var sqlda = new MySqlDataAdapter(command);
                sqlda.Fill(ds);
                conn.Close();
            }
            return ds;
        }

        public static int QueryCommand(MySqlCommand command)
        {
            int success;
            using (var conn = new MySqlConnection(connStr))
            {
                conn.Open();
                command.Connection = conn;
                success = command.ExecuteNonQuery();
                conn.Close();
            }

            return success;
        }
    }
}
