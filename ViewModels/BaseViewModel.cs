using HelloMauiApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloMauiApp.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        
        private INavigation _navigation;
        public ICommand GoBack { get; set; }
        

        public BaseViewModel(INavigation navigation)
        {
            _navigation = navigation;

            GoBack = new Command(() => _navigation.PopAsync());
        }

        #region properties

        private readonly IDataService _dataService;
        public IDataService DataService => _dataService ?? App.serviceProvider.GetService<IDataService>();

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set =>SetProperty(ref _isBusy, value);
        }

        #endregion

        #region privates
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Object.Equals(storage, value))
                return false;

            storage = value;
            OnPropertyChanged(propertyName);
            return true;
        }

        #endregion

        #region virtuals
        #endregion


    }
}
