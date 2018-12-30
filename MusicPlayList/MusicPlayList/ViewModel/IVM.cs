using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace MusicPlayList.ViewModel
{
    abstract class IVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        

        public void NotifyPropertyChanged(string propname)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
            }
        }
        public abstract void SendParametes();

        public abstract JArray GetParameters();

        public abstract void RecivedParameters(JArray arr);
    }
}
