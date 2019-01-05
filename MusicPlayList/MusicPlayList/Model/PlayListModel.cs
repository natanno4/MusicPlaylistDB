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
        private bool firstFlag = true;
        public event PropertyChangedEventHandler PropertyChanged;
        public SongPlaylist copyPlaylist
        {
            get; set;
        }

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
            if(firstFlag)
            {
                copyPlaylist = new SongPlaylist(Playlist);
                firstFlag = false;
            }
            arr.Add(JsonConvert.SerializeObject(Playlist));
            arr.Add(JsonConvert.SerializeObject(copyPlaylist));
            return arr;
        }
        public void SavePlaylistInTable ()
        {
            this.executer.connection.connect();
            StringBuilder query = new StringBuilder();
            foreach (Song sng in Playlist.Songs) {
                query.Append("insert into songs_in_playlist (Songs_idSongs, Songs_Album_idAlbum, Songs_Artists_idArtists ");
                query.Append(" , Playlist_idSongsPlaylist, Playlist_Users_idUsers) value("+sng.ID.ToString()+", "+sng.Album.ID.ToString()+", '"+sng.Artist.ID+"', "+Playlist.ID.ToString()+", "+Playlist.User.ID.ToString()+"))");
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
