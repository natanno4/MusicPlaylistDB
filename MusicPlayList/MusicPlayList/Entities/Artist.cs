using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Entities
{
    class Artist
    {
        private String name;
        private String genre;

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
        public String Genre
        {
            get
            {
                return genre;
            }
            set
            {
                this.genre = value;
            }
        }
    }
}
