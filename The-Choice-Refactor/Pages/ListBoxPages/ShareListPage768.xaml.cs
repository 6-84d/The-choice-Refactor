﻿using System;
using System.Collections.Generic;
using System.IO;
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
using The_Choice_Refactor.Classes;

namespace The_Choice_Refactor.Pages.ListBoxPages
{
    /// <summary>
    /// Interaction logic for ShareListPage768.xaml
    /// </summary>
    public partial class ShareListPage768 : Page
    {
        public ShareListPage768()
        {
            InitializeComponent();
        }
        private void Share_LstBx_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShareModel? selected = (sender as ListBox).SelectedItem as ShareModel;
            if (selected != null)
                Clipboard.SetText(selected.ToString());
        }

        private void favorite_ChBx_Checked(object sender, RoutedEventArgs e)
        {
            ShareModel? newFavorite = ((CheckBox)sender).DataContext as ShareModel;
            if (newFavorite != null)
            {
                StreamWriter writer = new StreamWriter(@"UserData\Favorites\FavoriteShares.txt", true);
                writer.WriteLine(newFavorite.symbol + ";");
                writer.Close();
            }
        }

        private void favorite_ChBx_Unchecked(object sender, RoutedEventArgs e)
        {
            ShareModel? removedFavorite = ((CheckBox)sender).DataContext as ShareModel;
            if (removedFavorite != null)
            {
                string temp = File.ReadAllText(@"UserData\Favorites\FavoriteShares.txt");
                StreamWriter writer = new StreamWriter(@"UserData\Favorites\FavoriteShares.txt");
                writer.Write(temp.Replace(removedFavorite.symbol + ";\r\n", ""));
                writer.Close();
            }
        }
    }
}
