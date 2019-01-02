using MusicPlayList.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.ViewModel
{
    class PlayListVM : IVM
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private PlayListModel playList_model;
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayListEditorVM"/> class.
        /// </summary>
        /// <param name="model">The model.</param>
        public PlayListVM()
        {
            this.playList_model = new PlayListModel();
            this.playList_model.PropertyChanged +=
                delegate (Object sender, PropertyChangedEventArgs e) {
                    this.PropertyChanged?.Invoke(this, e);
                };
        }
        override
        public void SendParameters()
        {
            BaseVM.instance.SendParam(BaseVM.ViewModels.PlayList, BaseVM.ViewModels.PlayListEditor);
        }
        override
        public JArray GetParameters()
        {
            return playList_model.ConvertToJson();
        }
        override
        public void RecivedParameters(JArray arr)
        {
            playList_model.ConvertFromJson(arr);
        }
        public void SaveAndExit()
        {
            this.playList_model.SavePlaylistInTable();

        }
    }
}
