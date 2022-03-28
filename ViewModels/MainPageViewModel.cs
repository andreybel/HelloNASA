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
        public ICommand GoData { get; set; }
        public ICommand GoCounter { get; set; }
        

        #endregion


        #region ctor
        public MainPageViewModel(INavigation navigation) : base(navigation)
        {

            GoData = new Command<string>(execute: (arg) => { ProcessData(arg); });
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

        private async Task ProcessData(string parameter)
        {
            if (string.IsNullOrEmpty(parameter)) return;
                
            await Navigation.PushAsync(new SettingsPage(parameter));
           
        }

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
