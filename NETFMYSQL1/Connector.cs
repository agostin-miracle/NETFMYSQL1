using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETFMYSQL1
{
    class Connector
    {
        public static bool Ready { get; set; } = false;
        public static MySqlConnection _connection;
        public static bool Get(string context = "DBACTIVECON")
        {
            Ready = false;
            string cs = System.Configuration.ConfigurationManager.ConnectionStrings[context].ConnectionString;
            if (!String.IsNullOrWhiteSpace(cs))
            {
                _connection = new MySqlConnection(cs);
                try
                {
                    if (_connection.State.Equals(ConnectionState.Closed))
                    {
                        _connection.Open();
                        Ready = true;
                    }
                }
                catch (MySqlException Error)
                {
                }
                finally
                {

                }
            }
            return Ready;
        }

        public static DataTable GetTable(string Sql)
        {
            DataTable dt = new DataTable();
            if (Ready)
            {
                MySqlDataAdapter da = new MySqlDataAdapter();
                try
                {
                    dt = new DataTable();
                    da = new MySqlDataAdapter(Sql, _connection);
                    da.Fill(dt);
                    da.Dispose();
                }
                catch
                {
                    throw;
                }
            }
            return dt;
        }

        public static void Close()
        {
            if (Ready)
            {
                _connection.Close();
                _connection.Dispose();
            }
        }

    }
}
