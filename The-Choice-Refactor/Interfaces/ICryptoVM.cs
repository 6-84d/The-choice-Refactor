﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using The_Choice_Refactor.Classes;

namespace The_Choice_Refactor.Interfaces
{
    public interface ICryptoVM
    {
        public ObservableCollection<CryptoModel> assets { get; set; }
        public CryptoModel? Selected { get; set; }
        public Task<bool> Load();
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "");
    }
}
