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
        }

        private void RemoveBtn_Click(object sender, RoutedEventArgs e)
        {
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            editorVM.SendParameters();
            Window playList = new PlayList();
            App.Current.MainWindow = playList;
            this.Close();
            playList.Show();
        }

        private void FilterBtn_click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.PlayListEditorVM)editorVM).Filter();
        }

        private void ResetBtn_Click(object sender, RoutedEventArgs e)
        {
            ((ViewModel.PlayListEditorVM)editorVM).reset();
        }
    }
}
