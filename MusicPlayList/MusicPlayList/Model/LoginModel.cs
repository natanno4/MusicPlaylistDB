using MusicPlayList.DataBase;
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

        public int FindUser(string user, String password)
        {
            dataBase.ExecuteCommandWithResults("think of quarry later");
            return 1;
        }
    }
}
