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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MapTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Map map = new Map();

        public string DisplayedImage
        {
            get { return map.MapImagePath; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }


       public void OnMapClick(object sender, MouseEventArgs e)
        {
            //calculate map statring point
            double mapminHeight = worldMap.Margin.Top;
            double mapminWidth = worldMap.Margin.Left;

            //calculate position x and y , for coordinates calculation
            Point p = e.GetPosition(this);
            //get map difference to default map.
            double[] dif = map.getMapSizeDiffernce();
            double x = (p.X - mapminWidth)/dif[0];
            double y = (p.Y - mapminHeight)/dif[1];
            map.fromPixelToCoordinates(x, y);
            double lon = map.CurrentLongitude;
            double la = map.CurrentLatitude;

            //draw circle
            Ellipse el = new Ellipse();
            el.Width = 5;
            el.Height = 5;
            el.Fill = new SolidColorBrush(Colors.Red);
            double left = p.X - (el.Width / 2);
            double top = p.Y - (el.Height / 2);
            el.Margin = new Thickness(left, top, 0, 0);
            el.VerticalAlignment = VerticalAlignment.Top;
            el.HorizontalAlignment = HorizontalAlignment.Left;
            girdMap.Children.Add(el);         
         }

    }
}
