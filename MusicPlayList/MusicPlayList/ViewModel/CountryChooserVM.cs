using MusicPlayList.Entities;
using MusicPlayList.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.ViewModel
{
    class CountryChooserVM : IVM
    {
        private CountryChooserModel countryChooser_model;
        public Dictionary<Area, int> Map
        {
            get
            {
                return countryChooser_model.AreaToNumberOfSongs;
            }
            set
            {
                countryChooser_model.AreaToNumberOfSongs = value;
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
