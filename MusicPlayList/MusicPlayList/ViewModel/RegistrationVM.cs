using MusicPlayList.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MusicPlayList.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MusicPlayList.ViewModel
{
    class RegistrationVM : IVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private RegistrationModel model;

        private TextBox textBoxUserName;
        private TextBox passwordBox;
        private TextBlock errorbox;

        string error = "";

        /// <summary>
        /// Initializes a new instance of the <see cref="RegistrationVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public RegistrationVM()
        {
            this.model = new RegistrationModel();
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e) {
                    this.PropertyChanged?.Invoke(this, e);
                };
        }

        public Boolean CheckRegistraion()
        {
            if (Username.Equals("")|| Password.Equals(""))
            {
                string temp = "One or More Fields missing";
                error = temp;
      
                return false;
            }
            error = "";
            if (model.SignUp())
            {
                // base class send parametres to next view model
                SendParameters();
                // so continue to next window   
                return true;
            } else
            {
                
                string temp = "Error was occured, please try again";
                error = temp;
                return false;
            }
        }
        public void resetinput()
        {
            passwordBox.Clear();
            textBoxUserName.Clear();
            error = "";
        }

        override
        public void SendParameters()
        {
            BaseVM.instance.SendParam(BaseVM.ViewModels.Registration, BaseVM.ViewModels.LocationMap);
        }
        override
        public JArray GetParameters() 
        {
            return model.ConvertToJson();
            
        }
        override
        public void RecivedParameters(JArray a)
        {
            ;
        }
        public String Username
        {
            get
            {
                return model.Username;
            }
            set
            {
                this.model.Username = value;
            }
        }
        public String Password
        {
            get
            {
                return model.Password;
            }
            set
            {
                this.model.Password = value;
            }
        }
    }
}
