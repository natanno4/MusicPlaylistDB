using MusicPlayList.DataBase;
using MusicPlayList.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
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
        private Dictionary<Area, int> AreasAndNumberOfSongs;

        private SongPlaylist model_playlist;
        public void ConvertFromJson(JArray j)
        {
            User = JsonConvert.DeserializeObject<User>(j[0].ToString());
            AreasAndNumberOfSongs = JsonConvert.DeserializeObject<Dictionary<Area, int>>(j[1].ToString());
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
            JObject j = QueryInterpreter.Instance.getQueryEntitesObject(QueryInterpreter.QueryType.CreateInitPlaylist, dt);
            model_playlist = JsonConvert.DeserializeObject<SongPlaylist>(j.ToString());

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
