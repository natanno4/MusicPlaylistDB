using MusicPlayList.Entities;
using MusicPlayList.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Shapes;

namespace MusicPlayList.ViewModel
{
    class LocationMapChooserVM : IVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LocationMapChooserModel model;
        public Image worldMap;
        private Ellipse el;
        private Grid gridMap;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationMapChooserVM"/> class.
        /// </summary>
        public LocationMapChooserVM()
        {
            this.model = new LocationMapChooserModel();
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e) {
                    this.PropertyChanged?.Invoke(this, e);
                };
        }
        //the function that will do binding when mouse clicked
        public void onChooseSpot(double X, double Y)
        {
            this.model.CalculateAreaProps(X, Y, worldMap.Margin.Top, worldMap.Margin.Left);
            Ellipse el = new Ellipse();
            el.Width = 5;
            el.Height = 5;
            el.Fill = new SolidColorBrush(Colors.Red);
            double left = X - (el.Width / 2);
            double top = Y - (el.Height / 2);
            el.Margin = new Thickness(left, top, 0, 0);
            el.VerticalAlignment = VerticalAlignment.Top;
            el.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            gridMap.Children.Add(el);
        }

        public void Finish()
        {
            this.model.CheckForClosestCountries();
            this.SendParameters();
        }

        override
        public void SendParameters()
        {
            BaseVM.instance.SendParam(BaseVM.ViewModels.LocationMap, BaseVM.ViewModels.PlayListEditor);
        }
        override
        public JArray GetParameters()
        {
            return model.ConvertToJson();

        }
        override
        public void RecivedParameters(JArray arr)
        {
            model.ConvertFromJson(arr);
        }
    }
}
