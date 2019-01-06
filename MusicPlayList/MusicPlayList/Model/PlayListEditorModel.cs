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
    /// <summary>
    /// PlayListEditorModel
    /// </summary>
    /// <seealso cref="System.ComponentModel.INotifyPropertyChanged" />
    class PlayListEditorModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The original playlist fromthe data base
        /// </summary>
        private SongPlaylist full_playlist;
        /// <summary>
        /// The model playlist from Playlist
        /// </summary>
        private SongPlaylist model_playlist;
        /// <summary>
        /// The working playlist
        /// </summary>
        private SongPlaylist new_playlist;
        /// <summary>
        /// The data base
        /// </summary>
        private DB_Executer dataBase;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayListEditorModel"/> class.
        /// </summary>
        public PlayListEditorModel()
        {
            dataBase = new DB_Executer();
        }

        public ObservableCollection<ExtensionInfo> CurrentGeners
        {
            get;set;
        }


        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the original play list.
        /// </summary>
        /// <returns></returns>
        public SongPlaylist OriginalPlayList
        {
            get
            {
                return model_playlist;
            }
            set
            {
                model_playlist = value;
            }

        }
        /// <summary>
        /// gets the current playlist.
        /// </summary>
        public SongPlaylist CurrentPlayList
        {
            get
            {
                return new_playlist;
            }
            set
            {
                new_playlist = value;
            }

        }

        public SongPlaylist CopyCurrentPlayList
        {
            get
            {
                return full_playlist;
            }
            set
            {
                full_playlist = value;
            }
        }
        /// <summary>
        /// Filter method.
        /// filter playlist according to user choice.
        /// first check for generes that user want, than clear
        /// the collection that the playlist is based on and add
        /// the appropriate songs to the playlist, and notify the viewmodel
        /// </summary>
        public void Filter()
        {
            List<string> genres = choosenGenres();
            if (genres.Count == 0)
            {
                return;
            }
            ObservableCollection<Song> temp = new ObservableCollection<Song>(CurrentPlayList.Songs);
            CurrentPlayList.Songs.Clear();
            foreach (Song song in temp)
            {
                if (genres.Contains(song.Artist.Genre))
                {
                    CurrentPlayList.Songs.Add(song);
                }
            }
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VM_GetPlayList"));
            CurrentGeners.Clear();
            resolveGenres(CurrentPlayList);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vm_CurrentGenres"));

        }
        /// <summary>
        /// choosenGeneres method.
        /// retrieve from user the genere that will
        /// be in the edited playlist
        /// </summary>
        /// <returns>list of strings (genres)</returns>
        private List<string> choosenGenres()
        {
            List<String> genres = new List<string>(); 
            foreach(ExtensionInfo ext in CurrentGeners)
            {
                if(ext.IsChecked)
                {
                    genres.Add(ext.Extension);
                    ext.IsChecked = false;
                }
            }
            return genres;
        }
        /// <summary>
        /// reset method.
        /// change the current playlist that is showed to the user 
        /// to the original playlist that he entered with to the
        /// editor.
        /// </summary>
        public void reset()
        {
            CurrentPlayList.Songs.Clear();
            CurrentGeners.Clear();
            foreach(Song item in OriginalPlayList.Songs)
            {
                CurrentPlayList.Songs.Add(item);
            }
            resolveGenres(CurrentPlayList);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VM_GetPlayList"));
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Vm_CurrentGenres"));

        }




        /*
        /// <summary>
        /// Filters the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        public void Filter_PlayList(ObservableCollection<String> filter)
        {
            int size = filter.Count();
            new_playlist = new SongPlaylist();
            new_playlist.ID = model_playlist.ID;
            new_playlist.User = model_playlist.User;
            String[] array_filter = filter.ToArray();
            Dictionary<String, String> map = new Dictionary<String, String>();
            /// <summary>
            /// Iterate over the filter and put the type subject and its type in a dictionary.
            /// </summary>
            for (int i = 0; i < size; i++)
            {
                String[] words = array_filter[i].Split(':');
                map.Add(words[0], words[1]);
            }
            /// <summary>
            /// Iterate over all the songs in the playlist and insert those who weren't in the filter into a new playlist.
            /// </summary>
            foreach (Song song in model_playlist.Songs)
            {
                if (map.ContainsKey("Hotness"))
                {
                    if (map["Hotness"].Equals(song.Hotness))
                    {
                        new_playlist.Songs.Add(song);
                    }
                }
                if (map.ContainsKey("Duration"))
                {
                    if (map["Duration"].Equals(song.Duration))
                    {
                        new_playlist.Songs.Add(song);
                    }
                }
                if (map.ContainsKey("Tempo"))
                {
                    if (map["Tempo"].Equals(song.Tempo))
                    {
                        new_playlist.Songs.Add(song);
                    }
                }
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Filter"));
            }
           
        }*/

        /** public void Sort(String sort)
         {
             //didnt do yet
         }**/
        /// <summary>
        /// ConvertToJson method.
        /// convert this window's parameters into a Jarray.
        /// </summary>
        /// <returns>Jarray with param</returns>
        public JArray ConvertToJson()
        {
            JArray j = new JArray();
            j.Add(JsonConvert.SerializeObject(CurrentPlayList));
            return j;
        }
        /// <summary>
        /// ConvertFromJson method.
        /// convert from jarray jtokens to the appropriate 
        /// params for this window
        /// </summary>
        /// <param name="j"></param>
        public void ConvertFromJson(JArray j)
        {
            OriginalPlayList = JsonConvert.DeserializeObject<SongPlaylist>(j[0].ToString());
            CurrentPlayList = new SongPlaylist(OriginalPlayList);
            CopyCurrentPlayList = new SongPlaylist(CurrentPlayList);
            CurrentGeners = new ObservableCollection<ExtensionInfo>();
            resolveGenres(CurrentPlayList);
        }

        /// <summary>
        /// resolveGeners method.
        /// resolve the generes from a given playlist
        /// </summary>
        /// <param name="playList">playlist</param>
        public void resolveGenres(SongPlaylist playList)
        {
            bool flag = true;
            foreach (Song item in playList.Songs)
            {
                foreach (ExtensionInfo ex in CurrentGeners)
                {
                    if(ex.Extension.Equals(item.Artist.Genre))
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    CurrentGeners.Add(new ExtensionInfo(item.Artist.Genre, 0));
                }
                flag = true;

            }
        }

    }

}