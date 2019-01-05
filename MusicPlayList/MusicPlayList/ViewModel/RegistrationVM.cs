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

        private TextBox username;
        private TextBox password;

        private TextBox messageToClient;
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
            Username = username.Text;
            Password = password.Text;
            if (Username.Equals("")|| Password.Equals(""))
            {
                messageToClient.AppendText("One or More Fields missing");
      
                return false;
            }
            messageToClient.Clear();
            if (model.SignUp())
            {
                // so continue to next window
                SendParameters();
                
                // base class send parametres to next view model
                return true;
            } else
            {
                messageToClient.Clear();
                messageToClient.AppendText("Error was occured, please try again");
                return false;
                // try again
            }
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
