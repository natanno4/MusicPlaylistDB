using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace MusicPlayList.ViewModel
{
    abstract class IVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private

        public void NotifyPropertyChanged(string propname)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propname));
            }
        }
        public abstract void SendParametes();
        
    }
}
