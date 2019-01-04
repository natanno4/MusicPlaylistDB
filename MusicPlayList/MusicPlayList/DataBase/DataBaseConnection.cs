using MySql.Data;
using MySql.Data.MySqlClient;
using System;

namespace MusicPlayList.DataBase
{
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
