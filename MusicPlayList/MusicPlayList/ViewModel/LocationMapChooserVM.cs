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
        public Boolean CircleFlag { get; set;}
        public Thickness EllipseMargin { get; set; } = new Thickness();

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationMapChooserVM"/> class.
        /// </summary>
        public LocationMapChooserVM()
        {
            CircleFlag = false;
            this.model = new LocationMapChooserModel();
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e) {
                    this.PropertyChanged?.Invoke(this, e);
                };
        }
        //the function that will do binding when mouse clicked
        public void onChooseSpot(double X, double Y, double marginTop, double marginLeft)
        {
            this.model.CalculateAreaProps(X, Y, marginTop, marginLeft);
            double left = X - marginLeft + 2;
            double top = Y - marginTop;
            EllipseMargin = new Thickness(left, top, 0, 0);
            NotifyPropertyChanged("EllipseMargin");
            CircleFlag = true;
            NotifyPropertyChanged("CircleFlag");
        }

        public void Finish()
        {
            CircleFlag = false;
            this.model.CheckForClosestCountries();
            this.SendParameters();
        }

        override
        public void SendParameters()
        {
            BaseVM.GetInstance.SendParam(BaseVM.ViewModels.LocationMap, BaseVM.ViewModels.AreaChooser);
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
