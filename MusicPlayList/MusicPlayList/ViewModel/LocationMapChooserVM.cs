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
        public Boolean CircleFlag;
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
            double left = X - 5;
            double top = Y - 5;
            EllipseMargin = new Thickness(left, top, 0, 0);
            CircleFlag = true;
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
