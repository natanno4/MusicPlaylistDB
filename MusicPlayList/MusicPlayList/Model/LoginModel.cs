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
        private String m_user;
        private String m_password;
        private DB_Executer dataBase;
        public event PropertyChangedEventHandler PropertyChanged;

        public JArray FindUser(string name, String password)
        {
            JArray user = dataBase.ExecuteCommandWithResults("think of quarry later");
            return user;
        }
    }
}
