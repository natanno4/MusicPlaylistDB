using MusicPlayList.DataBase;
using MusicPlayList.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private DB_Executer executer = new DB_Executer();
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

        public void savePlaylist()
        {
            int result = checkIfPlayListExist();
            if (result != -1)
            {
                playlist.ID = result;
                updatePlaylist();

            }
            else
            {
                createPlaylist();
                SavePlaylistInTable();
            } 

        }

        private void createPlaylist()
        {
            StringBuilder query = new StringBuilder();
            query.Append("Insert into playlist(playlist_name, Users_idUsers) values('" + playlist.User.Name +"'," + playlist.User.ID +")");
            int n = executer.ExecuteCommandWithoutResult(query.ToString());
            query.Clear();
            query.Append("select idSongsPlaylist from playlist where playlist_name = '" + playlist.User.Name + "' and Users_idUsers = " + playlist.User.ID.ToString());
            DataTable dt = executer.ExecuteCommandWithResults(query.ToString());
            playlist.ID = dt.Rows[0].Field<int>(0);
        }


        private void updatePlaylist()
        {
            bool flag = true;
            StringBuilder query = new StringBuilder();
            query.Append("select Songs_idSongs from songs_in_playlist where Playlist_idSongsPlaylist = " + playlist.ID.ToString());
            DataTable dt = executer.ExecuteCommandWithResults(query.ToString());
            query.Clear();
            executer.connection.connect();
            foreach (DataRow dr in dt.Rows)
            {
                foreach (Song song in playlist.Songs)
                {
                    if (dr.Field<int>(0) == song.ID)
                    {
                        flag = false;
                        break;
                    }
                }
                if (flag)
                {
                    query.Append("Delete from songs_in_playlist where Songs_idSongs = " + dr.Field<int>(0).ToString() + " and Playlist_idSongsPlaylist = " + playlist.ID.ToString());
                    executer.ExecuteQueryWithoutDisconnect(query.ToString());
                    query.Clear();
                }
                flag = true;
            }
            executer.connection.Close();
        } 

        private int checkIfPlayListExist()
        {
            StringBuilder query = new StringBuilder();
            query.Append("Select idSongsPlaylist from playlist where Users_idUsers = " + playlist.User.ID.ToString());
            DataTable dt = executer.ExecuteCommandWithResults(query.ToString());
            if (dt.Rows.Count != 0)
            {
                return dt.Rows[0].Field<int>(0);
            }
            return -1;  
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
                query.Append(", Playlist_idSongsPlaylist, Playlist_Users_idUsers) ");
                query.Append("value(" + sng.ID.ToString() + "," + sng.Album.ID.ToString() + ",'" + sng.Artist.ID +"'," + playlist.ID.ToString() + "," + playlist.User.ID.ToString() + ")");
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
