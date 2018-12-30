using MusicPlayList.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace MusicPlayList.ViewModel
{
    class LocationMapChooserVM : IVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LocationMapChooserModel model;

        private Double xPixel;
        private Double yPixel;
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
        public void onChooseSpot(object sender, MouseEventArgs e)
        {
            this.model.CalculateAreaProps(e.X, e.Y);
            this.model.CheckForClosesCountries();
        }

    }
}
