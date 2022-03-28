using HelloMauiApp.Interfaces;
using HelloMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiApp.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        #region ctor

        public SettingsPageViewModel(INavigation navigation) : base(navigation)
        {
            LoadData();
        }

        #endregion

        #region properties
        // Astronomy picture of the day
        private ApodDto _apod;
        public ApodDto Apod
        {
            get => _apod;
            set => SetProperty(ref _apod, value);
        }

        private string _abbr;
        public string Abbr
        {
            get => _abbr;
            set => SetProperty(ref _abbr, value);   
        }
        #endregion

        #region privates

        private async Task LoadData()
        {
            try
            {
                IsBusy = true;
                var response = await DataService.GetNasaApod();
                if (response != null)
                {
                    Apod = response;
                    Abbr = "APOD";
                }
            }
            finally
            {
                IsBusy = false;
            }
           
        }

        #endregion
    }
}
