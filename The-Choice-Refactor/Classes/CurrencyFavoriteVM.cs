﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace The_Choice_Refactor.Classes
{
    public class CurrencyFavoriteVM
    {
        public ObservableCollection<CurrencyModel> assets { get; set; }   // favorite currencies collection
        private CurrencyModel? selected;                                      // selected currency
        public CurrencyModel? Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged("Selected");
            }
        }
        public CurrencyFavoriteVM()
        {
            assets = new ObservableCollection<CurrencyModel>();
            Load();
        }
        public async void Load()
        {
            Dictionary<string, double> result = new Dictionary<string, double>();
            result = await CurrencyGet.Load();                                                                                  // get info from api

            string[] favoritesIDs = File.ReadAllText(@"UserData\Favorites\FavoriteCurrencies.txt").Split(";\r\n");     // load favorites list

            int i = 0;
            foreach (var res in result)
            {
                i++;

                CurrencyModel currency = new CurrencyModel();
                currency.number = i;

                if (favoritesIDs.Contains(res.Key))
                    currency.isFavorite = true;
                else continue;

                currency.name = res.Key;
                currency.price = res.Value;

                assets.Add(currency);
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
