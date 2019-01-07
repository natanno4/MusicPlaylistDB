﻿using MusicPlayList.View;
using MusicPlayList.ViewModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MusicPlayList
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            View.WindowLocationSeter.CenterWindowOnScreen(this);
            DataContext = this;
        }


        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            Window login = new Login();
            App.Current.MainWindow = login;
            this.Close();
            login.ShowDialog();
        }
    }
}