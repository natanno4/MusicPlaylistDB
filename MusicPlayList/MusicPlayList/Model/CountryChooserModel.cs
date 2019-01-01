using MusicPlayList.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Model
{
    class CountryChooserModel
    {
        private User user;
        private Dictionary<Area, int> AreasAndNumberOfSongs;
        public void ConvertFromJson(JArray j)
        {
            User = JsonConvert.DeserializeObject<User>(j[0].ToString());
            AreasAndNumberOfSongs = JsonConvert.DeserializeObject<Dictionary<Area, int>>(j[1].ToString());
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
