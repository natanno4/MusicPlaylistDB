using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace MusicPlayList.DataBase
{
    /// <summary>
    /// DataBaseConnection class.
    /// responsible of the connection of the application to the 
    /// database.
    /// </summary>
    class DataBaseConnection
    {
        private string databaseName =  string.Empty;
        private MySqlConnection connection = null;
        public static DataBaseConnection instance { get; } = new DataBaseConnection();

        private DataBaseConnection()
        {
            string connstring = string.Format("Server=localhost;database={0};uid=root;password={1}", "music_area_playlist", "12341234bhr");
            connection = new MySqlConnection(connstring);
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

        /// <summary>
        /// connnect function.
        /// connect to database.
        /// </summary>
        /// <returns>true if connect successfully else false</returns>
        public bool connect()
        {
            if (String.IsNullOrEmpty(databaseName))
            {
                //return false;
            }
            try
            { 
                connection.Open();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            return true;
        }
        /// <summary>
        /// Close function.
        /// close the connection.
        /// </summary>
        public void Close()
        {
            try
            {
                connection.Close();
            } catch (MySqlException e)
            {
                // the connection was faild to close
            }
        }



    }
}
