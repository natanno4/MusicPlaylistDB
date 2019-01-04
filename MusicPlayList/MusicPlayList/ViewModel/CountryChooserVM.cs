using MusicPlayList.Entities;
using MusicPlayList.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.ViewModel
{
    class CountryChooserVM : IVM
    {
        private CountryChooserModel countryChooser_model;

        public CountryChooserVM()
        {
            countryChooser_model = new CountryChooserModel();
        }

        public ObservableCollection<ExtensionInfo> Areas_count
        {
            get
            {
                return countryChooser_model.Areas_count;
            }
            set
            {
                countryChooser_model.Areas_count = value;
                NotifyPropertyChanged("Areas_count");
            }
        }



        override
        public void RecivedParameters(JArray arr)
        {
            countryChooser_model.ConvertFromJson(arr);

        }
        override
        public JArray GetParameters()
        {
            return countryChooser_model.ConvertToJson();
        }
        override
        public void SendParameters()
        {
            BaseVM.instance.SendParam(BaseVM.ViewModels.AreaChooser, BaseVM.ViewModels.PlayListEditor);
        }
        
    }
}
