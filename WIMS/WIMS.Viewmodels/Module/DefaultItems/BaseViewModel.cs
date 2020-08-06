using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Catel.MVVM;
using Catel.MVVM.Views;
using WIMS.Models.Module.DefaultItems;
using WIMS.Viewmodels.Module.DefaultItems.Services;
using Xamarin.Forms;

namespace WIMS.Viewmodels.Module.DefaultItems
{
    public class BaseViewModel : ViewModelBase
    {
        public IDataStore<Item> DataStore => DependencyService.Get<IDataStore<Item>>();

        private bool _isBusy;

        [ViewToViewModel(MappingType = ViewToViewModelMappingType.TwoWayViewModelWins)]
        public bool IsBusy
        {
            get => _isBusy;
            set => _isBusy = value;
        }
    }
}
