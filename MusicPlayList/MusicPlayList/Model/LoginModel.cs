using MusicPlayList.DataBase;
using MusicPlayList.Entities;
using Newtonsoft.Json;
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
        private User user;
        public event PropertyChangedEventHandler PropertyChanged;

        public User FindUser(string name, String password)
        {
            String query = "SELECT * FROM users WHERE users.user_name = name AND users.password = password";
            // user = dataBase.ExecuteCommandWithResults(query).First.ToObject<User>();
            user = JsonConvert.DeserializeObject<User>(dataBase.ExecuteCommandWithResults(query)[0].ToString());

            return user;
        }

        public JArray ConvertToJson()
        {
            JArray j = new JArray();
            j[0] = JsonConvert.SerializeObject(user);
            return j;
        }

        public void ConvertFromJson(JArray j)
        {
        }
    }
}
