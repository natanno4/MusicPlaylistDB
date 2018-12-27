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
    /// Interaction logic for PlayList.xaml
    /// </summary>
    public partial class PlayList : Window
    {
        public PlayList()
        {
            InitializeComponent();
        }

        private void BtmEdit_Click(object sender, RoutedEventArgs e)
        {
            PlayListEditor editor = (PlayListEditor)Application.Current.MainWindow;
            editor.Show();
            this.Close();
        }

        private void BtmExit_Click(object sender, RoutedEventArgs e)
        {
            Login login = (Login)Application.Current.MainWindow;
            login.Show();
            this.Close();
        }
    }
}
