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
    /// Interaction logic for LocationMapChooser.xaml
    /// </summary>
    public partial class LocationMapChooser : Window
    {
        private ViewModel.IVM locationChooserVM = ViewModel.BaseVM.instance._LocationMapChoosenVM;
        public LocationMapChooser()
        {
            InitializeComponent();
            this.DataContext = locationChooserVM;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            Window editor = new PlayListEditor();
            editor.Show();
        }
    }
}