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
    /// Interaction logic for CountryChooser.xaml
    /// </summary>
    public partial class CountryChooser : Window
    {
        //private ViewModel.IVM countryChooserVM = ViewModel.BaseVM.instance.;

        public CountryChooser()
        {
            InitializeComponent();
        }

        private void ContinueBtn_Click(object sender, RoutedEventArgs e)
        {
                Window editor = new PlayListEditor();
                editor.Show();
        }
    }
    
}
