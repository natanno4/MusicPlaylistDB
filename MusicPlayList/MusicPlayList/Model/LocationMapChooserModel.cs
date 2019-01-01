using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayList.Entities;
using MusicPlayList.DataBase;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Data;

namespace MusicPlayList.Model
{
    class LocationMapChooserModel : INotifyPropertyChanged
    {
        private Map map;
        public event PropertyChangedEventHandler PropertyChanged;
        public DB_Executer executer;
        private Area area;
        private User user;
        private Dictionary<Area, int> mapper;
        private ObservableCollection<String> areasName = new ObservableCollection<string>();

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
        public void CheckForClosestCountries()
        {
            // need to be changed later, maybe in sunday
            StringBuilder subQuery = null;
            subQuery.Append("SELECT area.location_name, area.location_id FROM musicareaplaylist.area ");
            subQuery.Append("WHERE area.latitude != 0 AND area.longitude != 0 ");
            subQuery.Append("GROUP BY area.location_name ");
            subQuery.Append("ORDER BY (6371 * acos( cos( radians(area.latitude) ) * cos( radians("+ area.Latitude.ToString()+ ")) * cos( radians("+ area.Longtitude.ToString()+") - radians(area.longitude) ) ");
            subQuery.Append("+ sin( radians(area.latitude) ) * sin(radians(" + area.Latitude.ToString() + "))))");
            subQuery.Append("Asc \n LIMIT 10");
            String query = "SELECT area.location_name, COUNT(song_name) FROM (" + subQuery + ") AS country JOIN artist JOIN Songs WHERE Songs.artist_id = artist.id AND artist.location_id = country.location_id GROUP BY country.location_name ORDER BY count(song)";
            DataTable set = this.executer.ExecuteCommandWithResults(query);
            JObject j = QueryInterpreter.Instance.getQueryEntitesObject(QueryInterpreter.QueryType.AreaSongsCount, set);
            Mapper = JsonConvert.DeserializeObject<Dictionary<Area, int>>(j.ToString());

        }
        public Dictionary<Area, int> Mapper
        {
            get
            {
                return mapper;
            }
            set
            {
                this.mapper = value;
            }
        }
        private void FromJTokenToString(JArray arr)
        {
            foreach (JToken j in arr) {
                this.areasName.Add(j.First.ToString());
            }
        }
        public User User
        {
            get
            {
                return user;
            }
            set
            {
                user = value;
            }
        }
        public Area Area
        {
            get
            {
                return area;
            }
            set
            {
                area = value;
            }
        }
        public JArray ConvertToJson(DataTable areas)
        {
            JArray j = new JArray();
            j[0] = JsonConvert.SerializeObject(User);
            // for now we send list of countries directly to Editor
            // j[1] = JsonConvert.SerializeObject(Area);
            j[2] = JsonConvert.SerializeObject(Mapper);
            return j;
        }
        
        public void ConvertFromJson(JArray j)
        {
            User = JsonConvert.DeserializeObject<User>(j[0].ToString());
        }
    }
}
