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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public Registration()
        {
            InitializeComponent();
        }

        private void CancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Login win = (Login)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            //TODO: cheak if the passwords are matched and add the data to the DB
            //vm.SaveSettings();
            MainWindow win = (MainWindow)Application.Current.MainWindow;
            win.Show();
            this.Close();
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            textBoxUserName.Clear();
            textBoxLastName.Clear();
            textBoxFirstName.Clear();
            passwordBox.Clear();
            passwordBoxConfirm.Clear();
        }
    }
}
