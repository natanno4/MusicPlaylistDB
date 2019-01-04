using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayList.DataBase;
using MySql.Data.MySqlClient;
using MusicPlayList.Entities;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Data;

namespace MusicPlayList.Model
{
    class RegistrationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DB_Executer executer = new DB_Executer();
        public User user = new User();

        public void getIDFromTable()
        {
            String query = "SELECT idUsers FROM users WHERE user_name = '" + Username + "' AND password = '" + Password + "'";
            DataTable dt = executer.ExecuteCommandWithResults(query);
            ID = dt.Rows[0].Field<int>(0);
        }
        public Boolean SignUp()
        {
            String checkIfUserExist = "Select * FROM Users WHERE user_name = '" + Username + "' AND password = '" + Password +"'";
            if (executer.ExecuteCommandWithResults(checkIfUserExist).Rows.Count != 0)
            {
                return false;
            }
            String query = "INSERT INTO Users (user_name, password) VALUES ('" +  Username + "','" + Password + "')";
            if (executer.ExecuteCommandWithoutResult(query) != -1)
            {
                getIDFromTable();
                return true;
            }
            return false;
                
        }

        public JArray ConvertToJson()
        {
            JArray arr = new JArray();
            arr.Add(JsonConvert.SerializeObject(this.user));
            return arr;
        }
        public void ConvertFromJson()
        {
            ;
        }
        public int ID
        {
            get
            {
                return user.ID;
            }
            set
            {
                user.ID = value;
            }
        }
        public String Password
        {
            get
            {
                return user.Password;
            }
            set
            {
                user.Password = value;
            }
        }
        public String Username
        {
            get
            {
                return user.Name;
            }
            set
            {
                this.user.Name = value;
            }
        } 
    }
}
