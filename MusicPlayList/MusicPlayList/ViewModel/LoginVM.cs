using MusicPlayList.Entities;
using MusicPlayList.Model;
using Newtonsoft.Json.Linq;
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
        private LoginModel model;
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Initializes a new instance of the <see cref="LoginVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public LoginVM()
        {
            this.model =  new LoginModel();
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e) {
                   this.PropertyChanged?.Invoke(this, e);
                };
        }

        public string Name
        {
            get { return model.User.Name; }
            set
            {
                model.User.Name = value;
                NotifyPropertyChanged("Name");
            }
        }

        public string Password
        {
            get
            {
                return model.User.Password;
            }
            set
            {
                model.User.Password = value;
                NotifyPropertyChanged("Password");
            }
        }

        public Boolean Confirm()
        {
           if(!model.FindUser())
            {

            }
            this.SendParameters();
            // return user != null;
            return true;
        }

        override
        public void SendParameters()
        {
            BaseVM.GetInstance.SendParam(BaseVM.ViewModels.Login, BaseVM.ViewModels.PlayList);
        }

        override
        public JArray GetParameters()
        {
            return model.ConvertToJson();

        }

        override
        public void RecivedParameters(JArray arr)
        {
            model.ConvertFromJson(arr);
        }

    }
}
