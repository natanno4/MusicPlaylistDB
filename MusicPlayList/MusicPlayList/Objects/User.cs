using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList
{
    class User
    {
        private int userID;
        private String name;
        private String password;

        public User(int userID, String name, String password)
        {
            this.userID = userID;
            this.name = name;
            this.password = password;
        }

        public int UserID
        {
            get { return userID; }
            set { }
        }
        public string Name
        {
            get { return name; }
            set { }
        }
        public string Password
        {
            get { return password; }
            set { }
        }
    }
}
