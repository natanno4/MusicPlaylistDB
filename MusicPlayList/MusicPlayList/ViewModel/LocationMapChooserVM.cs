using MusicPlayList.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.ViewModel
{
    class LocationMapChooserVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private LocationMapChooserModel model;

        private Double lattiude;
        private Double longttitude;
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
        
    }
}
