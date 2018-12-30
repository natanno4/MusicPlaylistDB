using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayList.ViewModel
{
    class BaseVM
    {

        private BaseVM()
        {
        }

        public static BaseVM instance { get; } = new BaseVM();

        private IVM loginVM = new LoginVM();
        public IVM _LoginVM
        {
            get
            {

                return loginVM;
            }
        }

        private IVM locationMapChoosenVM = new LocationMapChooserVM();
        public IVM _LocationMapChoosenVM
        {
            get
            {
                return locationMapChoosenVM;
            }
        }

        private IVM mainWindowVM = new MainWindowVM();
        public IVM _MainWindowVM
        {
            get
            {
                return mainWindowVM;
            }
        }

        private IVM playListEditorModel = new PlayListEditorVM();
        public IVM _PlayListEditorVM
        {
            get
            {
                return playListEditorModel;
            }
        }


        private IVM playListVM = new PlayListVM();
        public IVM _PlayListVM
        {
            get
            {
                return playListVM;
            }
        }


        private IVM registrationVM = new RegistrationVM();
        public IVM _RegistrationVM
        {
            get
            {
                return registrationVM;
            }
        }

    }
}
