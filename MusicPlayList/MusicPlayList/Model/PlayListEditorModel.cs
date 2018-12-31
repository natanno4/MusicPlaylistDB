using MusicPlayList.DataBase;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.Model
{
    class PlayListEditorModel : INotifyPropertyChanged
    {
        private ObservableCollection<String> model_playlist;
        private DB_Executer dataBase;

        public PlayListEditorModel()
        {
            model_playlist = new ObservableCollection<string>();
            dataBase = new DB_Executer()
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<String> GetPlayList()
        {
            return model_playlist;
        }

        public void Filter(String filter)
        {
            dataBase.ExecuteCommandWithoutResult(filter);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Filter"));
        }

        public void Sort(String sort)
        {
            dataBase.ExecuteCommandWithoutResult(sort);
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Sort"));
        }
    }
    
}
