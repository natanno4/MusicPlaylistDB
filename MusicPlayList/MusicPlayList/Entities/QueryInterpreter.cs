using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Entities
{
    class QueryInterpreter
    {
        public enum QueryType { ResolveInitialPlaylist, AreaSongsCount, GetUser};
        private QueryInterpreter() { }
        public static QueryInterpreter Instance { get; } = new QueryInterpreter();
        
        public JObject getQueryEntitesObject(QueryType q, DataTable dt)
        {
            JObject obj = null;
            switch(q)
            {
                case QueryType.AreaSongsCount:
                    {
                        obj = GetAreaSongsCount(dt);
                        break;
                    }
                case QueryType.ResolveInitialPlaylist:
                    {
                        obj = getPlaylist(dt);
                        break;
                    }
                case QueryType.GetUser:
                    {
                        obj = getUser(dt);
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }
            return obj;
        }

        private JObject getUser(DataTable dt)
        {
            User us = new User();
            us.ID = dt.Rows[0].Field<int>(0);
            us.Name = dt.Rows[0].Field<String>(1);
            us.Password = dt.Rows[0].Field<String>(2);
            return JObject.FromObject(us);
        }
        private JObject GetAreaSongsCount(DataTable dt)
        {
            Dictionary<Area, int> song_in_area = new Dictionary<Area, int>();
            foreach (DataRow row in dt.Rows)
            {
                Area a = new Area();
                a.Id = row.Field<int>(0);
                a.AreaName = row.Field<string>(1);
                int count = row.Field<int>(2);
                song_in_area.Add(a, count);
            }
            return JObject.FromObject(song_in_area);
        }
        private JObject getPlaylist(DataTable dt)
        {
            SongPlaylist playlist = new SongPlaylist();
            ObservableCollection<Song> list = new ObservableCollection<Song>();

            foreach (DataRow row in dt.Rows)
            {
                Song sng = new Song();
                sng.ID = row.Field<int>(0);
                sng.Name = row.Field<string>(1);
                sng.Year = row.Field<int>(2);
                sng.Hotness = row.Field<Double>(3);
                sng.Duration = row.Field<Double>(4);
                sng.Tempo = row.Field<Double>(5);
                sng.Artist.ID = row.Field<string>(6);
                sng.Artist.Name = row.Field<string>(7);
                sng.Artist.Genre = row.Field<String>(8);
                sng.Album.ID = row.Field<int>(9);
                sng.Album.Name = row.Field<string>(10);
                list.Add(sng);
            }
            playlist.Songs = list;
            return JObject.FromObject(playlist);
        }
    }
}
