using MusicPlayList.DataBase;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Model
{
    class LoginModel : INotifyPropertyChanged
    {
        private DB_Executer dataBase = new DB_Executer();
        public event PropertyChangedEventHandler PropertyChanged;

        public User FindUser(string name, String password)
        {
            String query = "think of query later";
            User user = dataBase.ExecuteCommandWithResults(query).First.ToObject<User>();
            return user;
        }
    }
}
