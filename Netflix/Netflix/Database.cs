using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace Netflix
{
    internal class Database
    {
        private const string CONNECTIONSTRING = "Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST={0})(PORT={1}))(CONNECT_DATA=(SERVICE_NAME={2})));User Id={3};Password={4};";

        private readonly OracleConnection connection;

        /// <summary>
        /// Creates a database connection and connects to it
        /// </summary>
        /// <param name="username">The username with whicht you want to log in</param>
        /// <param name="password">The password corresponding to the username</param>
        /// <param name="ipAdress">The ipadress of the server</param>
        /// <param name="hostname">The name you are know as by the server</param>
        /// <param name="port">the port to whicht to connect</param>
        public Database(string username, string password, string ipAdress = "192.168.15.50", string hostname = "fhictora", string port = "1521")
        {
            connection =
                new OracleConnection(String.Format(CONNECTIONSTRING, ipAdress, port, hostname, username, password));
            //connection.Open();
        }

        /// <summary>
        /// Run a query with no result
        /// </summary>
        /// <param name="query">The query which to run</param>
        /// <returns>Amount of rows affected</returns>
        public int QueryNoResult(String query)
        {
            //open connection and run command in non query mode
            connection.Open();
            var command = new OracleCommand(query, connection);
            var result = command.ExecuteNonQuery();
            connection.Close();
            return result;
        }

        /// <summary>
        /// Run a scalar request(one response)
        /// </summary>
        /// <typeparam name="T">The type to cast te respons to</typeparam>
        /// <param name="query">The query to run</param>
        /// <returns>The value from the response as type T</returns>
        public T QueryScalar<T>(String query)
        {
            //open connection an execute in scalar mode
            connection.Open();
            var comand = new OracleCommand(query, connection);
            //cast result to <T>
            T result = (T)comand.ExecuteScalar();
            connection.Close();
            return result;
        }

        /// <summary>
        /// Runs a query and get a reader to read all data, run CloseConnection() after command
        /// </summary>
        /// <param name="query">The query to run</param>
        /// <returns>The reader object wich you can get all data from</returns>
        public OracleDataReader QueryReader(String query)
        {
            //open connection and and execute a command in reader mode
            connection.Open();
            var command = new OracleCommand(query, connection);
            return command.ExecuteReader();
        }

        /// <summary>
        /// Closes the connection, run after Query Reader
        /// </summary>
        public void CloseConnection()
        {
            connection.Close();   
        }

    }
}
