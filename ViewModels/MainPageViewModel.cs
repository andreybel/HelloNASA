using HelloMauiApp;
using HelloMauiApp.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloMauiApp.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        #region fields
        public ICommand GoApod { get; set; }
        public ICommand GoCounter { get; set; }
        

        #endregion


        #region ctor
        public MainPageViewModel(INavigation navigation) : base(navigation)
        {
            GoApod = new Command(execute: () => navigation.PushAsync(new SettingsPage()));
            GoCounter = new Command(execute: () => { ProcessCounter(); });
        }

        #region properties

        private int _counter = 0;
        public int Counter
        {
            get => _counter;
            set => SetProperty(ref _counter, value);
        } 

        #endregion

        #endregion

        #region commands

        private void ProcessCounter()
        {
            _counter++;
            OnPropertyChanged(nameof(Counter)); 
        }

        #endregion

        #region privates

       

        #endregion
    }
}
