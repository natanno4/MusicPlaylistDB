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
        private String m_name;
        private String vm_password;
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public LoginVM()
        {
            this.model =  new LoginModel();
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

        public Boolean Confirm()
        {
            User user = model.FindUser(m_name, Password);
            this.SendParameters();
            return user != null;
        }

        override
        public void SendParameters()
        {
            BaseVM.instance.SendParam(BaseVM.ViewModels.Login, BaseVM.ViewModels.PlayList);
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
