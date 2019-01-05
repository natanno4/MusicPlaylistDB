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
        public String Error { get; set; } = "";

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
        // need to make a button that will call this function
        public void ChooseRandom()
        {
            this.countryChooser_model.GetRandomAreas();
            SendParameters();
        }


        public bool chooseCountry()
        {
            bool check = countryChooser_model.CreateInitPlaylist();
            if(check)
            {
                Error = "";
                NotifyPropertyChanged("Error");
                SendParameters();
                return check;
            }
            Error = "Please Choose Areas!";
            NotifyPropertyChanged("Error");
            return false;
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
            BaseVM.GetInstance.SendParam(BaseVM.ViewModels.AreaChooser, BaseVM.ViewModels.PlayList);
        }
        
    }
}
