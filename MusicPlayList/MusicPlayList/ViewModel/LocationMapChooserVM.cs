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
    class LocationMapChooserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LocationMapChooserModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="LocationMapChooserVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public LocationMapChooserVM(LocationMapChooserModel model)
        {
            this.model = model;
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e) {
                    this.PropertyChanged?.Invoke(this, e);
                };
        }
        //the function that will do binding when mouse clicked
        public void onChooseSpot(object sender, MouseEventArgs e)
        {
            this.model.CalculateAreaProps(e.X, e.Y, worldMap.Margin.Top, worldMap.Margin.Left);
            this.model.CheckForClosestCountries();
        }

    }
}
