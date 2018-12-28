using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Entities
{
    class User
    {
        private string name;
        private string password;


        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                this.password = value;
            }
        }
        public User() { };
        public User(string userName, string email, string password)
        {
            this.name = userName;
            this.password = password;
        }
    }
}
