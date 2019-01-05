using MusicPlayList.DataBase;
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
        public DB_Executer executer = new DB_Executer();
        private Dictionary<Area, int> AreasAndNumberOfSongs = new Dictionary<Area, int>();
        public ObservableCollection<ExtensionInfo> Areas_count = new ObservableCollection<ExtensionInfo>();



        private SongPlaylist model_playlist = new SongPlaylist();
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
                Areas_count.Add(new ExtensionInfo(item.AreaName, count));
            }
        }



        private String KeysToString()
        {
            StringBuilder build = new StringBuilder();
            build.Append("");
            bool flag = true;
            foreach(ExtensionInfo ex in Areas_count)
            {
                if (ex.IsChecked)
                {
                    foreach (Area a in AreaToNumberOfSongs.Keys)
                    {
                        if(a.AreaName.Equals(ex.Extension))
                        {
                            if(!flag)
                            {
                                build.Append("," + a.Id.ToString());
                            }
                            else
                            {
                                build.Append(a.Id.ToString());
                                flag = false;
                            }
                            
                        }
                    }
                }
            }
            return build.ToString();
        }
        public bool CreateInitPlaylist()
        {

            string str = KeysToString();
            if(String.IsNullOrEmpty(str))
            {
                return false;
            }
            StringBuilder query = new StringBuilder();
            query.Append("SELECT idSongs,song_name,year,song_hotness,song_duration,song_tempo,artists_from_areas.idArtists,artists_from_areas.artist_name,artists_from_areas.genre,album_name,idAlbum ");
            query.Append("FROM songs JOIN (SELECT idArtists, artist_name, genre FROM artists WHERE Area_LocationId in (" + str + ") GROUP BY idArtists) AS artists_from_areas ");
            query.Append("join album ");
            query.Append("WHERE songs.Artists_idArtists = artists_from_areas.idArtists and songs.Album_idAlbum = album.idAlbum GROUP BY idSongs order by idSongs");
            DataTable dt = executer.ExecuteCommandWithResults(query.ToString());
            ObservableCollection<string> list = JsonConvert.DeserializeObject<ObservableCollection<string>>(QueryInterpreter.Instance.getQueryEntitesObject(QueryInterpreter.QueryType.ResolveInitialPlaylist, dt));
            ObservableCollection<Song> songs = new ObservableCollection<Song>();
            foreach (string item in list)
            {
                songs.Add(JsonConvert.DeserializeObject<Song>(item));
            }
            model_playlist.Songs = songs;
            model_playlist.User = User;
            return true;

        }
        public JArray ConvertToJson()
        {
            JArray arr = new JArray();
            arr.Add(JsonConvert.SerializeObject(model_playlist));
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
        public void GetRandomAreas()
        {
            String query = "SELECT * FROM Songs JOIN Artist JOIN Area WHERE song.artist_id = artist.artist_id AND artist.areaID = area.areaID AND area.areaID IN(" + CheckForRandomAreas() + ")";
            DataTable dt = executer.ExecuteCommandWithResults(query);
            // need to continue and pass the param
        }
        public string CheckForRandomAreas()
        {
            StringBuilder q = new StringBuilder();
            q.Append("SELECT TOP 8 LocationId, location_name ");
            q.Append("FROM music_area_playlist.area WHERE area.longitude = 0 AND area.latitude = 0");
            DataTable dt = executer.ExecuteCommandWithResults(q.ToString());
            StringBuilder areasID= new StringBuilder();
            areasID.Append("(");
            foreach (DataRow d in dt.Rows)
            {
                areasID.Append(d.Field<int>(0).ToString() + ",");
            }
            areasID.Append(")");
            return areasID.ToString();
        }
    }
}
