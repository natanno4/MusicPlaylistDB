using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Entities
{
    class Album
    {
        private String name;

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
    }
}
