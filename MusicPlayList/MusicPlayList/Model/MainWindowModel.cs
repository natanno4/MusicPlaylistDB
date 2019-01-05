using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Model
{
    class MainWindowModel
    {
        public string Extension { get; set; }
        public bool IsChecked { get; set; }
        public int Count { get; set; }

        public ExtensionInfo(string extension, int c)
        {
            Extension = extension;
            Count = c; 
        }
    }
}
