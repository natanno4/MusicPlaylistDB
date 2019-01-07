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

        private ViewModel.IVM playListVM = ViewModel.BaseVM.GetInstance._PlayListVM;

        public PlayList()
        {
            InitializeComponent();
            WindowLocationSeter.CenterWindowOnScreen(this);
            this.DataContext = playListVM;
        }

        private void BtmEdit_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.PlayListVM)playListVM).SendParameters();
            Window editor = new PlayListEditor();
            App.Current.MainWindow = editor;
            this.Close();
            editor.Show();
        }

        private void BtmExit_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.PlayListVM)playListVM).SaveAndExit();
            Window mainWin = new MainWindow();
            App.Current.MainWindow = mainWin;
            this.Close();
            mainWin.Show();
        }
    }
}
