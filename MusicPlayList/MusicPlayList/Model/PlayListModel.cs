using MusicPlayList.DataBase;
using MusicPlayList.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Model
{
    class PlayListModel : INotifyPropertyChanged
    {
        private SongPlaylist playlist;
        private DB_Executer executer;
        public event PropertyChangedEventHandler PropertyChanged;

        public SongPlaylist Playlist
        {
            get
            {
                return playlist;
            }
            set
            {
                playlist = value;
            }
        }
        public void ConvertFromJson(JArray arr)
        {
            Playlist = JsonConvert.DeserializeObject<SongPlaylist>(arr[0].ToString());

        }
        public JArray ConvertToJson()
        {
            
            JArray arr = new JArray();
            arr[0] = JsonConvert.SerializeObject(Playlist);
            return arr;
        }
        public void SavePlaylistInTable ()
        {
            this.executer.connection.connect();
            StringBuilder query = new StringBuilder();
            foreach (Song sng in Playlist.Songs) {
                query.Append("INSERT INTO songs_in_playlist(Songs_idSongs, Songs_Album_idAlbum, Songs_Artists_idArtists , Playlist_idSongsPlaylist, Playlist_Users_idUsers)");
                query.Append(" VALUES(");
                query.Append(sng.ID + "," + sng.Album.ID + "," + sng.Artist.ID + "," + Playlist.ID + "," + Playlist.User.ID);
               int n =  executer.ExecuteQueryWithoutDisconnect(query.ToString());
                if (n != 1)
                {
                    // may be will change later, need to pay attention
                    break;
                }
                query.Clear();
            }
            this.executer.connection.Close();
        }
    }

}
