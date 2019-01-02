using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using MySql.Data.MySqlClient;
using System.Data;

namespace MusicPlayList.DataBase
{
    class DB_Executer
    {
        public DataBaseConnection connection = DataBaseConnection.instance;
        /// <summary>
        /// execute witouth result
        /// </summary>
        /// <param name="query"></param>
        /// <returns>return -1 if there was a problem with 
        /// the conncetion or the query, else return the number of
        /// rows that was affected by the query
        public int ExecuteCommandWithoutResult(String query)
        {
            MySqlCommand command = ResolveCommand(query);
            if (this.connection.connect())
            {
                int status;
                try
                {
                    status = command.ExecuteNonQuery(); 
                } catch (MySqlException e)
                {
                    //connactin faild
                    return -1;
                }
                this.connection.Close();
                return status;
            }
            return -1;
        }
        public int ExecuteQueryWithoutDisconnect(String query)
        {
            MySqlCommand command = ResolveCommand(query);
            int s;
            try
            {
                s = command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                // do smoething
            }
            return s; 
        }
        public DataTable ExecuteCommandWithResults(String query)
        {
            MySqlCommand command = ResolveCommand(query);
            if (this.connection.connect())
            try
            {
                    JArray resultTable = new JArray();
                  /* MySqlDataReader reader = command.ExecuteReader();
                    /*
                   while (reader.Read())
                   {
                       JObject row = new JObject();
                       int numberOfCols = reader.FieldCount;
                       for (int i = 0; i < numberOfCols; i++)
                       {                        
                           row[reader.GetName(i).ToString()] = reader[i].ToString();
                       }
                       resultTable.Add(row);
                       resultTable.Next
                   }
                   reader.Close();
                   this.connection.Close();
                   return resultTable;*/
                }
                catch (MySqlException e)
                {
                    // temporary
                    return null; 

                }
            MySqlDataReader reader = command.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(reader);
            return dt;
        }
        // function that might be, for now leave it
        public int ExecuteAgger()
        {
            return 0;
        }
        private MySqlCommand ResolveCommand(String q)
        {
            MySqlCommand cmd = new MySqlCommand();
            cmd.CommandText = q;
            cmd.Connection = this.connection.Connection;
            return cmd;
        }
    }
}
