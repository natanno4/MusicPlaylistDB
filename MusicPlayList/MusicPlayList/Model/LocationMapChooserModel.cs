using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayList.Entities;
using MusicPlayList.DataBase;

namespace MusicPlayList.Model
{
    class LocationMapChooserModel : INotifyPropertyChanged
    {
        private Map map;
        public event PropertyChangedEventHandler PropertyChanged;
        public DB_Executer executer;
        private Area area;

        public Boolean CalculateAreaProps(Double xVal, Double yVal)
        {
            //from xaml
            double mapminHeight = worldMap.Margin.Top;
            double mapminWidth = worldMap.Margin.Left;

            double[] dif = map.getMapSizeDiffernce();
            double x = (xVal - mapminWidth) / dif[0];
            double y = (yVal - mapminHeight) / dif[1];
            map.fromPixelToCoordinates(x, y);
            area.Longtitude = map.CurrentLongitude;
            area.Latitude = map.CurrentLatitude;
        }
        public JArray CheckForClosesCountries()
        {
            // need to be changed later, maybe in sunday
            String query = "" + area.Latitude + "" + area.Longtitude;
            JArray set = this.executer.ExecuteCommandWithResults(query);
        }
    }
}
