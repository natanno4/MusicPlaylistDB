using MusicPlayList.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.ViewModel
{
    class LoginVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LoginModel model;
        private String vm_user;
        private String vm_password;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public LoginVM(LoginModel model)
        {
            this.model = model;
         //?   this.model.PropertyChanged +=
            //    delegate (Object sender, PropertyChangedEventArgs e) {
              //      this.PropertyChanged?.Invoke(this, e);
                //};
        }

        public string User
        {
            get { return vm_user; }
            set
            {
                vm_user = value;
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

        public void Confirm()
        {
            int x;
            if (model.FindUser(User, Password))
            {
                x = 5;
            }
                
        }

    }
}
