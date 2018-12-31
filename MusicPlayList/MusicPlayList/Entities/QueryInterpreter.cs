using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Entities
{
    class QueryInterpreter
    {
        public enum QueryType { AreaSongsCount};
        private QueryInterpreter() { }
        public static QueryInterpreter Instance { get; } = new QueryInterpreter();
        
        public JObject getQueryEntitesObject(QueryType q, DataTable dt)
        {
            switch(q)
            {
                case QueryType.AreaSongsCount:
                    {
                        GetAreaSongsCount(dt);
                        break;
                    }
                default:
                    {
                        return null;
                    }
            }
            return null;
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
    }
}
