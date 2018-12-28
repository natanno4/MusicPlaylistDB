using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayList.Entities;

namespace MusicPlayList.Model
{
    class LocationMapChooserModel : INotifyPropertyChanged
    {
        private Map map;
        public event PropertyChangedEventHandler PropertyChanged;
        
        public Boolean CalculateAreaProps(Double xVal, Double yVal)
        {
            double mapminHeight = worldMap.Margin.Top;
            double mapminWidth = worldMap.Margin.Left;

            double[] dif = map.getMapSizeDiffernce();
            double x = (xVal - mapminWidth) / dif[0];
            double y = (yVal - mapminHeight) / dif[1];
            map.fromPixelToCoordinates(x, y);
            double lon = map.CurrentLongitude;
            double la = map.CurrentLatitude;
        }
    }
}
