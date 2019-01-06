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

        private ViewModel.IVM loginVM;

        public Login()
        {
            InitializeComponent();

            ViewModel.BaseVM baseVM = ViewModel.BaseVM.GetInstance;
            loginVM = baseVM._LoginVM;
            this.DataContext = loginVM;
        }

        private void BtnSubmit_Click(object sender, RoutedEventArgs e)
        {
            Boolean result = ((ViewModel.LoginVM)loginVM).Confirm();
            if (result)
            {
                Window playList = new PlayList();
                App.Current.MainWindow = playList;
                this.Close();
                playList.Show();
            }
        }

        private void BtnSignUp_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.LoginVM)loginVM).clear();
            Window reg = new Registration();
            App.Current.MainWindow = reg;
            this.Close();
            reg.Show();
        }


    }
}
