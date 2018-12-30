using MusicPlayList.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.ViewModel
{
    class LoginVM : IVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LoginModel model;
        private String m_name;
        private String vm_password;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public LoginVM()
        {
            this.model = new LoginModel();
         //?   this.model.PropertyChanged +=
            //    delegate (Object sender, PropertyChangedEventArgs e) {
              //      this.PropertyChanged?.Invoke(this, e);
                //};
        }

        public string User
        {
            get { return m_name; }
            set
            {
                m_name = value;
            }
        }
        public string Password
        {
            get { return vm_password; }
            set
            {
                vm_password = value;
            }
        }

        public int Confirm()
        {
            int userID = model.FindUser(m_name, Password).UserID;
            return userID;
        }

    }
}
