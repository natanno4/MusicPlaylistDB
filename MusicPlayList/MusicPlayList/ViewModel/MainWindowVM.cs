using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicPlayList.Model;

namespace MusicPlayList.ViewModel
{
    class MainWindowVM :IVM
    {
        private MainWindowModel model;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindowVM"/> class.
        /// </summary>
        public MainWindowVM()
        {
            this.model = new MainWindowModel();
        }
    }
}
