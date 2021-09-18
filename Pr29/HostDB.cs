using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySqlConnector;

namespace Pr29
{
    /// <summary>
    /// Класс для работы с удалённой БД на хостинге Reg.ru.
    /// </summary>
    static class HostDB
    {
        public static MySqlConnection ConnectionDB = new MySqlConnection(ConfigurationManager.ConnectionStrings["HOST_DB_connection_string"].ConnectionString);


        public async static Task OpenConnection()
        {
            if (ConnectionDB.State == System.Data.ConnectionState.Closed)
               await ConnectionDB.OpenAsync();
        }

        public static void CloseConnection()
        {
            if (ConnectionDB.State == System.Data.ConnectionState.Open)
                ConnectionDB.Close();
        }


    }
}
