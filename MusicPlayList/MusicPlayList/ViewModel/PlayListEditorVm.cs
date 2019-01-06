using MusicPlayList.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using MusicPlayList.Entities;

namespace MusicPlayList.ViewModel
{
    class PlayListEditorVM : IVM
    {
        private PlayListEditorModel model;
        private String[] vm_filter;
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
                    this.NotifyPropertyChanged("VM_" + e.PropertyName);
                };
        }

        public ObservableCollection<ExtensionInfo> Vm_CurrentGenres
        {
            get
            {
                return model.CurrentGeners;
            }
            set
            {
                model.CurrentGeners = value;
                NotifyPropertyChanged("Vm_CurrentGenres");
            }
        }

        public SongPlaylist VM_GetPlayList
        {
            get { return model.CurrentPlayList; }
            set
            {
                this.model.CurrentPlayList = value;
                NotifyPropertyChanged("VM_GetPlayList");
            }
        }

        public void reset()
        {
            model.reset();
        }


        public void Filter()
        {
            this.model.Filter();
        }
        /*
        public String[] VM_Filter_PlayList
        {
            set {
                this.vm_filter = value;
               // model.Filter_PlayList(this.vm_filter);;
            }
        }
        */

        override
        public void SendParameters()
        {
            BaseVM.GetInstance.SendParam(BaseVM.ViewModels.PlayListEditor, BaseVM.ViewModels.PlayList);
        }

        override
        public JArray GetParameters()
        {
            return model.ConvertToJson();
        }

        override
        public void RecivedParameters(JArray arr)
        {
            model.ConvertFromJson(arr);
        }
    }
}
