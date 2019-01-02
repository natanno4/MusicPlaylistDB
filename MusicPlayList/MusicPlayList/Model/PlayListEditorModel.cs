﻿using MusicPlayList.DataBase;
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
        /// The model playlist
        /// </summary>
        private SongPlaylist model_playlist;
        /// <summary>
        /// The model playlist
        /// </summary>
        private SongPlaylist new_playlist;
        /// <summary>
        /// The data base
        /// </summary>
        private DB_Executer dataBase;
        /// <summary>
        /// The value
        /// </summary>
        private string value;

        /// <summary>
        /// Initializes a new instance of the <see cref="PlayListEditorModel"/> class.
        /// </summary>
        public PlayListEditorModel()
        {
            dataBase = new DB_Executer();
        }

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Gets the play list.
        /// </summary>
        /// <returns></returns>
        public SongPlaylist GetPlayList()
        {
            return model_playlist;
        }

        /// <summary>
        /// Filters the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        public void Filter_PlayList(String[] filter)
        {
            int size = filter.Count();
            new_playlist = new SongPlaylist();
            new_playlist.ID(model_playlist.ID);
            Dictionary<String, String> map = new Dictionary<String, String>();
            /// <summary>
            /// Iterate over the filter and put the type subject and its type in a dictionary.
            /// </summary>
            for (int i = 0; i < size; i++)
            {
                String[] words = filter[i].Split(':');
                map.Add(words[0], words[1]);
            }
            /// <summary>
            /// Iterate over all the songs in the playlist and insert those who weren't in the filter into a new playlist.
            /// </summary>
            foreach (Song song in model_playlist.Songs)
            {
                if(map.ContainsKey("Hotness"))
                {
                    if(map["Hotness"].Equals(song.Hotness))
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

        }

        public void Sort(String sort)
        {
            //didnt do yet
        }

        public JArray ConvertToJson()
        {
            JArray j = new JArray();
            j[0] = JsonConvert.SerializeObject(new_playlist);
            return j;
        }

        public void ConvertFromJson(JArray j)
        {
            model_playlist = JsonConvert.DeserializeObject<SongPlaylist>(j[0].ToString());
            new_playlist = model_playlist;
        }
    }
    
}
