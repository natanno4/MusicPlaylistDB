using MusicPlayList.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.ViewModel
{
    class PlayListEditorVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PlayListEditorModel model;
        private int vm_user_id;
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayListEditorVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public PlayListEditorVM(PlayListEditorModel model)
        {
            this.model = model;
        }
        public int UserID
        {
            get { return vm_user_id; }
            set
            {
                vm_user_id = value;
            }
        }
    }
}
