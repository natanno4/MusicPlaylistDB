
using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace MusicPlayList.DataBase
{
    class DataBaseConnection
    {
        private string databaseName =  string.Empty;
        private MySqlConnection connection = null;
        private static DataBaseConnection instance = null;

        private DataBaseConnection()
        {
        }

        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }

        public string Password { get; set; }

        public MySqlConnection Connection
        {
            get { return connection; }
        }

        public bool isConnected()
        {
            if (connection == null)
            {
                return false;
            }
            return true;
        }

        public bool connect()
        {
            if (String.IsNullOrEmpty(databaseName))
            {
                return false;
            }
            try
            { 
                string connstring = string.Format("Server=localhost; database={0}; UID=root; password={1}", databaseName, Password);
                connection = new MySqlConnection(connstring);
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }

        public void Close()
        {
            connection.Close();
        }



    }
}
