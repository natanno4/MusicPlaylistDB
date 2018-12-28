using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayList.DataBase;
using MySql.Data.MySqlClient;
using MusicPlayList.Entities;

namespace MusicPlayList.Model
{
    class RegistrationModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public DB_Executer executer = new DB_Executer();
        private User user = new User();


        public Boolean SignUp()
        {
     
            String query = "INSERT INTO Users (user name, password) VALUES (" + Username + "," + Password + ")";
            if (executer.ExecuteCommandWithoutResult(query) != -1)
            {
                return true;
            }
            return false;
                
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
