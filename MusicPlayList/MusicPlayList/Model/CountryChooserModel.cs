﻿using MusicPlayList.DataBase;
using MusicPlayList.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Model
{
    class CountryChooserModel
    {
        private User user;
        public DB_Executer executer;
        private Dictionary<Area, int> AreasAndNumberOfSongs = new Dictionary<Area, int>();
        public ObservableCollection<ExtensionInfo> Areas_count = new ObservableCollection<ExtensionInfo>();



        private SongPlaylist model_playlist;
        public void ConvertFromJson(JArray j)
        {
            User = JsonConvert.DeserializeObject<User>(j[0].ToString());
            Dictionary<string, int> tempDic = JsonConvert.DeserializeObject<Dictionary<string, int>>(j[1].ToString());
            foreach (string item in tempDic.Keys)
            {
                int count;
                tempDic.TryGetValue(item, out count);
                Area temp = JsonConvert.DeserializeObject<Area>(item);
                AreasAndNumberOfSongs.Add(temp, count);
            }
            CreateAreasList();
            
        }

        private void CreateAreasList()
        {
            foreach (Area item in AreasAndNumberOfSongs.Keys)
            {
                int count;
                AreasAndNumberOfSongs.TryGetValue(item, out count);
                string str = string.Format("{0}-{1}", item.AreaName, count);
                Areas_count.Add(new ExtensionInfo(str));
            }
        }


        private String KeysToString()
        {
            StringBuilder build = null;
            foreach (Area a in AreaToNumberOfSongs.Keys)
            {
                build.Append("'" + a.AreaName + "',");
            }
            return build.ToString();
        }
        public void CreateInitPlaylist()
        {
            String query = "SELECT * FROM Songs JOIN Artist JOIN Area WHERE song.artist_id = artist.artist_id AND artist.areaID = area.areaID AND area.location_name IN(" + KeysToString() +")";
            DataTable dt = executer.ExecuteCommandWithResults(query);
            //JObject j = QueryInterpreter.Instance.getQueryEntitesObject(QueryInterpreter.QueryType.ResolveInitialPlaylist, dt);
            //model_playlist = JsonConvert.DeserializeObject<SongPlaylist>(j.ToString());
            //model_playlist.User = User;

        }
        public JArray ConvertToJson()
        {
            JArray arr = new JArray();
            arr[0] = JsonConvert.SerializeObject(model_playlist);
            return arr;
        }
        public Dictionary<Area, int> AreaToNumberOfSongs
        {
            get
            {
                return AreasAndNumberOfSongs;
            }
            set
            {
                AreasAndNumberOfSongs = value;
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
    }
}
