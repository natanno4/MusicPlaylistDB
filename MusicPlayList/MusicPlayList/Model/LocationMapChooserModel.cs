using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayList.Entities;
using MusicPlayList.DataBase;
using Newtonsoft.Json.Linq;

namespace MusicPlayList.Model
{
    class LocationMapChooserModel : INotifyPropertyChanged
    {
        private Map map;
        public event PropertyChangedEventHandler PropertyChanged;
        public DB_Executer executer;
        private Area area;

        public Boolean CalculateAreaProps(Double xVal, Double yVal, Double mapMinHeight, Double mapMinWidth)
        {
            //from xaml
            double[] dif = map.getMapSizeDiffernce();
            double x = (xVal - mapMinWidth) / dif[0];
            double y = (yVal - mapMinHeight) / dif[1];
            map.fromPixelToCoordinates(x, y);
            area.Longtitude = map.CurrentLongitude;
            area.Latitude = map.CurrentLatitude;

            return true;
        }
        public JArray CheckForClosestCountries()
        {
            // need to be changed later, maybe in sunday
            StringBuilder query = null;
            query.Append("SELECT area.location_name FROM musicareaplaylist.area ");
            query.Append("WHERE area.latitude != 0 AND area.longitude != 0 ");
            query.Append("GROUP BY area.location_name ");
            query.Append("ORDER BY (6371 * acos( cos( radians(area.latitude) ) * cos( radians("+ area.Latitude.ToString()+ ")) * cos( radians("+ area.Longtitude.ToString()+") - radians(area.longitude) ) ");
            query.Append("+ sin( radians(area.latitude) ) * sin(radians(" + area.Latitude.ToString() + "))))");
            query.Append("Asc \n LIMIT 10");
            JArray set = this.executer.ExecuteCommandWithResults(query.ToString());
            return set;
        }
    }
}
