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
    /// <summary>
    /// PlayListModel class.
    /// responsible of showing the playlist to user, with option
    /// to edit/save and exit.
    /// </summary>
    class PlayListModel : INotifyPropertyChanged
    {
        private SongPlaylist playlist;
        private DB_Executer executer;
        public event PropertyChangedEventHandler PropertyChanged;
        public SongPlaylist copyPlaylist
        {
            get; set;
        }
        /// <summary>
        /// Playlist.
        /// </summary>
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
        /// <summary>
        /// ConvertFromJson method.
        /// convert the jarray token's into appropriate
        /// parameters, in this case - playlist
        /// </summary>
        /// <param name="arr"></param>
        public void ConvertFromJson(JArray arr)
        {
            Playlist = JsonConvert.DeserializeObject<SongPlaylist>(arr[0].ToString());

        }
        /// <summary>
        /// ConvertToJson method.
        /// convert this window's parameters into a Jarray.
        /// </summary>
        /// <returns>Jarray with param</returns>
        public JArray ConvertToJson()
        {

            JArray arr = new JArray();
            arr.Add(JsonConvert.SerializeObject(Playlist));
            return arr;
        }
        /// <summary>
        /// SavePlaylistInTable method.
        /// save the desired playlist of user in table.
        /// first connect to database, and then insert it into table
        /// </summary>
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
