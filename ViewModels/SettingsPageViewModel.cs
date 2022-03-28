using HelloMauiApp.Interfaces;
using HelloMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloMauiApp.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public ICommand GoSelectCamera { get; set; }

        #region ctor

        public SettingsPageViewModel(INavigation navigation) : base(navigation)
        {
            GoSelectCamera = new Command<string>((args)=> { ProcessSelectCamera(args); });
        }

        #endregion

        #region properties
        public string Parameter { get; set; } = string.Empty;

        public bool IsEpics => Epics!=null && Epics.Any();
        public bool IsApod => Apod != null;
        public bool IsMars => Parameter.Equals("MARS");

        private ObservableCollection<string> _cameraTypes;
        public ObservableCollection<string> CameraTypes
        {
            get=> _cameraTypes;
            set=>SetProperty(ref _cameraTypes, value);
        }

        private ObservableCollection<MarsPhoto> _marsPhotos;
        public ObservableCollection<MarsPhoto> MarsPhotos
        {
            get => _marsPhotos;
            set => SetProperty(ref _marsPhotos, value);
        }

        // Astronomy picture of the day
        private ApodDto _apod;
        public ApodDto Apod
        {
            get => _apod;
            set 
            {
                if (SetProperty(ref _apod, value))
                {
                    OnPropertyChanged(nameof(IsApod));
                }
            }
        }

        private MarsDto _mars;
        public MarsDto Mars
        {
            get => _mars;
            set => SetProperty(ref _mars, value);
        }

        private ObservableCollection<EpicDto> _epics;
        public ObservableCollection<EpicDto> Epics 
        {
            get => _epics;
            set 
            {
                if(SetProperty(ref _epics, value))
                {
                    OnPropertyChanged(nameof(IsEpics));
                }
            } 
        }


        private string _abbr;
        public string Abbr
        {
            get => _abbr;
            set => SetProperty(ref _abbr, value);   
        }
        #endregion

        #region commands

        private async Task ProcessSelectCamera(string camera)
        {
            if (string.IsNullOrEmpty(camera)) return;

            try
            {
                IsBusy = true;
                var response = await DataService.GetMarsData(camera.ToLower());
                if (response == null) return;

                Mars = response;
                MarsPhotos = new ObservableCollection<MarsPhoto>(Mars.photos);
                OnPropertyChanged(nameof(Mars));
                OnPropertyChanged(nameof(MarsPhotos));
            }
            finally
            {
                IsBusy = false;
            }

          
        }

        #endregion

        #region overrides

        public override async Task Initialize(object parameter = null)
        {
            try
            {
                IsBusy = true;

                if (parameter != null && parameter is string val)
                {
                    if (val.Equals("APOD"))
                    {
                        var response = await DataService.GetNasaApod();
                        if (response != null)
                        {
                            Apod = response;
                            Abbr = parameter.ToString();
                        }
                    }
                    else if (val.Equals("EPIC"))
                    {
                        var response = await DataService.GetNasaEpic();
                        if (response != null)
                        {
                            Epics = new ObservableCollection<EpicDto>(response);
                            Abbr = parameter.ToString();
                        }
                    }
                    else if (val.Equals("MARS"))
                    {
                        OnPropertyChanged(nameof(IsMars));
                        Abbr = parameter.ToString();

                        CameraTypes = new ObservableCollection<string> 
                        {
                            "FHAZ","RHAZ","MAST","CHEMCAM","MAHLI","MARDI", "NAVCAM"//, "PANCAM","MINITES"
                        };

                        OnPropertyChanged(nameof(CameraTypes));
                    }

                }

            }
            finally
            {
                IsBusy = false;
                await base.Initialize(parameter);
            }


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

       private EpicDto MapEpicData(EpicDto epic)
       {
            var output = new EpicDto();

            if (epic == null) return output;

            epic.ImageUrl = $"{epic.image}";

            return output;
       }

        #endregion
    }
}
