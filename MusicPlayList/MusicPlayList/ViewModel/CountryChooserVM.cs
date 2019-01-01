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
        public void RecievedRecivedParameters(JArray arr)
        {
            countryChooser_model.ConvertFromJson(arr);

        }
        override
        public JArray GetParameters()
        {
            // temporary
            return new JArray();
        }
        override
        public void SendParameters()
        {
            BaseVM.instance.SendParam(BaseVM.ViewModels.AreaChooser, BaseVM.ViewModels.PlayListEditor);
        }
    }
}
