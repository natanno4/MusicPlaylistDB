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

namespace MusicPlayList.ViewModel
{
    class RegistrationVM : INotifyPropertyChanged
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
        public RegistrationVM(RegistrationModel model)
        {
            this.model = model;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e) {
                    this.PropertyChanged?.Invoke(this, e);
                };
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Username = username.Text;
            Password = password.Text;
            if (Username.Equals("" )|| Password.Equals(""))
            {
                messageToClient.AppendText("One or More Fields missing");
      
                return;
            }
            messageToClient.Clear();
            if (model.SignUp())
            {
                // so continue to next window
                User user = model.user;
            } else
            {
                messageToClient.Clear();
                messageToClient.AppendText("Error was occured, please try again");
                // try again
            }
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
