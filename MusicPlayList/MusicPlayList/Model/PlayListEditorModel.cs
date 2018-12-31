using MusicPlayList.DataBase;
using MusicPlayList.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Model
{
    class PlayListEditorModel : INotifyPropertyChanged
    {
        private ObservableCollection<Song> model_playlist;
        private DB_Executer dataBase;

        public PlayListEditorModel()
        {
            dataBase = new DB_Executer();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<Song> GetPlayList()
        {
            return model_playlist;
        }

        public void Filter(String filter)
        {
            ObservableCollection<Song> new_playlist = new ObservableCollection<Song>();
            string[] words = filter.Split(':');
            foreach (Song song in model_playlist)
            {                
                if(!words[0].Equals("Hotness"))
                {
                    if(!words[1].Equals(song.Hotness))
                    {
                        new_playlist.Add(song);
                    }
                }
                if (!words[0].Equals("Duration"))
                {
                    if (!words[1].Equals(song.Duration))
                    {
                        new_playlist.Add(song);
                    }
                }
                if (!words[0].Equals("Tempo"))
                {
                    if (!words[1].Equals(song.Tempo))
                    {
                        new_playlist.Add(song);
                    }
                }
                model_playlist = new_playlist;
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Filter"));

            }
                //dataBase.ExecuteCommandWithoutResult(filter);
                //this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Filter"));

        }

        public void Sort(String sort)
        {
            dataBase.ExecuteCommandWithoutResult(sort);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sort"));
        }

        public JArray ConvertToJson()
        {
            JArray j = new JArray();
            j[0] = JsonConvert.SerializeObject(model_playlist);
            return j;
        }

        public void ConvertFromJson(JArray j)
        {
            model_playlist = JsonConvert.DeserializeObject<ObservableCollection<Song>>(j[0].ToString());
        }
    }
    
}
