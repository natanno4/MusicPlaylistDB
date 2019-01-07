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
        private ViewModel.IVM locationChooserVM = ViewModel.BaseVM.GetInstance._LocationMapChoosenVM;
        public LocationMapChooser()
        {
            InitializeComponent();
            WindowLocationSeter.CenterWindowOnScreen(this);
            this.DataContext = locationChooserVM;
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            if (((ViewModel.LocationMapChooserVM)locationChooserVM).Finish())
            {
                Window chooser = new CountryChooser();
                App.Current.MainWindow = chooser;
                this.Close();
                chooser.Show();
            }
        }
        private void OnMapClick(object sender, MouseEventArgs e)
        {
            Point p = e.GetPosition(this);
            double top = border.Margin.Top + panel.Margin.Top + label.Height + separtor.Height + gridMap.Margin.Top + worldMap.Margin.Top;
            double left = border.Margin.Left + panel.Margin.Left + gridMap.Margin.Left + worldMap.Margin.Left;
            ((ViewModel.LocationMapChooserVM)locationChooserVM).onChooseSpot(p.X, p.Y, top, left);
        }
       
    }
}