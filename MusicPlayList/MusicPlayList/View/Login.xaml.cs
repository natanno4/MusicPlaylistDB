using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicPlayList.View
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            //InitializeComponent();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            // TODO: need to check if the user and password exist and connect him if it does else error message
            PlayList playList = (PlayList)Application.Current.MainWindow;
            playList.Show();
            this.Close();

        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            Registration registration = (Registration)Application.Current.MainWindow;
            registration.Show();
            this.Close();
        }


    }
}
