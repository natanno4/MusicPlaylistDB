using MusicPlayList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.ViewModel
{
    class PlayListEditorVM : IVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PlayListEditorModel model;
        private String vm_filter;
        private String vm_sort;
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayListEditorVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public PlayListEditorVM()
        {
            this.model = new PlayListEditorModel();
            this.model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e) {
                    this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("VM_" + e.PropertyName));
                };
        }

        public ObservableCollection<String> VM_GetPlayList
        {
            get { return model.GetPlayList(); }
        }

        public String VM_Filter
        {
            set {
                this.vm_filter = value;
                String query = "write query here";
                model.Filter(query);
            }
        }

        public String VM_Sort
        {
            set
            {
                this.vm_sort = value;
                String query = "write query here";
                model.Sort(query);
            }
        }
    }
}
