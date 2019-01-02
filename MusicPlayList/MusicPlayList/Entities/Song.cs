using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Entities
{
    class Song
    {
        private int song_id;
        private String name;
        private int year;
        private Double hotness;
        private Double duration;
        private Double tempo;
        private String artist;
        private String genre;

        public int ID
        {
            get
            {
                return song_id;
            }
            set
            {
                song_id = value;
            }
        }
        public String Genere

        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
            }
        }
        public String Artist
        {
            get
            {
                return artist;
            }
            set
            {
                artist = value
            }
        }
        public String Name
        {
            get
            {
                return name;
            }
            set
            {
                this.name = value;
            }
        }
        public int Year
        {
            get
            {
                return year;
            }
            set
            {
                this.year = value;
            }
        }
        public Double Hotness
        {
            get
            {
                return hotness;
            }
            set
            {
                this.hotness = value;
            }
        }
        public Double Duration
        {
            get
            {
                return duration;
            }
            set
            {
                this.duration = value;
            }
        }
        public Double Tempo
        {
            get
            {
                return tempo;
            }
            set
            {
                this.tempo = value;
            }
        }
    }
}
