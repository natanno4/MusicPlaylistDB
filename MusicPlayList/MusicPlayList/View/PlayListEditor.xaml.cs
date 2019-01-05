using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MusicPlayList.View
{
    /// <summary>
    /// Interaction logic for PlayListEditor.xaml
    /// </summary>
    public partial class PlayListEditor : Window
    {
        private ViewModel.IVM editorVM = ViewModel.BaseVM.GetInstance._PlayListEditorVM;

        public PlayListEditor()
        {
            InitializeComponent();
            this.DataContext = editorVM;
            //this.DataContext = new PlayListEditorViewModel();
            //vm = new SettingsViewModel(new SettingsModel());
            //DataContext = vm;
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
            //vm.VM_HandlerClose((string)lstBox.SelectedItem);
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Window playList = new PlayList();
            playList.Show();
        }
    }
}
