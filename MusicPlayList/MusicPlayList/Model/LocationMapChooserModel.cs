﻿using System;
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
        public Map map = new Map();
        public event PropertyChangedEventHandler PropertyChanged;
        public DB_Executer executer = new DB_Executer();
        private Area area = new Area();
        private User user;
        private Dictionary<Area, int> mapper = new Dictionary<Area, int>();
        private ObservableCollection<String> areasName = new ObservableCollection<string>();

        public void CalculateAreaProps(Double xVal, Double yVal, Double mapMinHeight, Double mapMinWidth)
        {
            //from xaml
            double[] dif = map.getMapSizeDiffernce();
            double x = (xVal - mapMinWidth) / dif[0];
            double y = (yVal - mapMinHeight) / dif[1];
            map.fromPixelToCoordinates(x, y);
            area.Longtitude = map.CurrentLongitude;
            area.Latitude = map.CurrentLatitude;
        }
        public void CheckForClosestCountries()
        {
            // need to be changed later, maybe in sunday
            StringBuilder subQuery = new StringBuilder();
            subQuery.Append("Select LocationId, location_name, count(location_name) FROM ");
            subQuery.Append("(SELECT area.LocationId,area.location_name FROM music_area_playlist.area ");
            subQuery.Append("WHERE area.latitude != 0 AND area.longitude != 0 ");
            subQuery.Append("GROUP BY area.location_name ");
            subQuery.Append("order by (6371 * acos( cos( radians(area.latitude) ) * cos( radians(" + area.Latitude.ToString() + ")) ");
            subQuery.Append("* cos( radians("+Area.Longtitude.ToString()+") - radians(area.longitude) ) + sin( radians(area.latitude) ) * sin(radians("+Area.Latitude.ToString()+")))) Asc ");
            subQuery.Append("LIMIT 8) AS country ");
            subQuery.Append("JOIN artists JOIN Songs ");
            subQuery.Append("WHERE songs.artists_idArtists = artists.idArtists AND artists.Area_LocationId = country.LocationId ");
            subQuery.Append("GROUP BY location_name order by count(location_name) desc ");
            /*
            subQuery.Append("+ sin( radians(area.latitude) ) * sin(radians(" + area.Latitude.ToString() + "))))");
            subQuery.Append("Asc \n LIMIT 10");
            String query = "SELECT area.location_name, COUNT(song_name) FROM (" + subQuery + ") AS country JOIN artist JOIN Songs WHERE Songs.artist_id = artist.id AND artist.location_id = country.location_id GROUP BY country.location_name ORDER BY count(song)";
           */
            DataTable set = this.executer.ExecuteCommandWithResults(subQuery.ToString());
            string ans = QueryInterpreter.Instance.getQueryEntitesObject(QueryInterpreter.QueryType.AreaSongsCount, set);
            Dictionary<string,int> tempDic = JsonConvert.DeserializeObject<Dictionary<string, int>>(ans);
            foreach (string item in tempDic.Keys)
            {
                int count;
                tempDic.TryGetValue(item, out count);
                Mapper.Add(JsonConvert.DeserializeObject<Area>(item), count);
            }

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
        /*
        private void FromJTokenToString(JArray arr)
        {
            foreach (JToken j in arr) {
                this.areasName.Add(j.First.ToString());
            }
        }
        */
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
        public JArray ConvertToJson()
        {
            JArray j = new JArray();
            j.Add(JsonConvert.SerializeObject(User));
            Dictionary<string, int> tempDict = new Dictionary<string, int>();
            foreach(Area item in Mapper.Keys)
            {
                int count;
                Mapper.TryGetValue(item, out count);
                tempDict.Add(JsonConvert.SerializeObject(item), count);
            }
            j.Add(JsonConvert.SerializeObject(tempDict));
            return j;
        }
        
        public void ConvertFromJson(JArray j)
        {
            User = JsonConvert.DeserializeObject<User>(j[0].ToString());
        }

    }
}
