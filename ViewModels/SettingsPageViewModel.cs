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
        public ICommand GoSelectMarsSource { get; set; }

        #region ctor

        public SettingsPageViewModel(INavigation navigation) : base(navigation)
        {
            GoSelectCamera = new Command<CameraTypeVm>((args)=> { ProcessSelectCamera(args); });
            GoSelectMarsSource = new Command<string>((args) => { ProcessSelectMarsSource(args); });
        }

        #endregion

        #region properties
        public string Parameter { get; set; } = string.Empty;

        public bool IsEpics => Epics!=null && Epics.Any();
        public bool IsApod => Apod != null;
        public bool IsMars => Parameter.Equals("MARS");

        private bool _isMarsByCamera;
        public bool IsMarsByCamera
        {
            get => _isMarsByCamera;
            set=> SetProperty(ref _isMarsByCamera, value);
        }

        private bool _isMarsByDate;
        public bool IsMarsByDate
        {
            get => _isMarsByDate;
            set => SetProperty(ref _isMarsByDate, value);
        }

        private ObservableCollection<CameraTypeVm> _cameraTypes;
        public ObservableCollection<CameraTypeVm> CameraTypes
        {
            get=> _cameraTypes;
            set=>SetProperty(ref _cameraTypes, value);
        }

        private ObservableCollection<MarsPhoto> _marsPhotos = new ObservableCollection<MarsPhoto>();
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

        private ControlTemplate _currentTemplate;
        public ControlTemplate CurrentTemplate
        {
            get => _currentTemplate;
            set => SetProperty(ref _currentTemplate, value);
        }


        private string _abbr;
        public string Abbr
        {
            get => _abbr;
            set => SetProperty(ref _abbr, value);   
        }

        private DateTime _selectedDate = DateTime.Now;
        public DateTime SelectedDate
        {
            get => _selectedDate;
            set
            {
                if(SetProperty(ref _selectedDate, value))
                {
                    _selectedDate = value;
                    Task.Run(() => GetMarsPhotosByDate(_selectedDate.ToString("yyyy-MM-dd")));

                }
            }
        }

        public DateTime MaxDate => DateTime.Today;
        #endregion

        #region commands

        private async Task ProcessSelectCamera(CameraTypeVm camera)
        {
            if (camera == null) return;

            try
            {
                IsBusy = true;
                foreach (var item in CameraTypes)
                {
                    if (!item.Equals(camera))
                    {
                        item.IsSelected = false;
                        continue;
                    };

                    item.IsSelected = true;

                    OnPropertyChanged(nameof(item));
                }
                var response = await DataService.GetMarsDataByCameraType(camera.Type.ToLower());
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

        private async Task ProcessSelectMarsSource(string source)
        {
            if (string.IsNullOrEmpty(source)) return;

            try
            {
                MarsPhotos?.Clear();
                if (source.Equals("ByCamera"))
                {
                    IsMarsByDate = false;
                    IsMarsByCamera = !IsMarsByDate;
                    await ProcessSelectCamera(CameraTypes?.FirstOrDefault());
                    // CurrentTemplate = new ControlTemplate(typeof(MarsByCamera));
                }
                if (source.Equals("ByDate"))
                {
                    IsMarsByCamera = false;
                    IsMarsByDate = !IsMarsByCamera;
                    //CurrentTemplate = new ControlTemplate(typeof(MarsByDate));
                }

                OnPropertyChanged(nameof(MarsPhotos));
                OnPropertyChanged(nameof(CurrentTemplate));
            }
            catch (Exception)
            {

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
                    Abbr = parameter.ToString();
                    if (val.Equals("APOD"))
                    {
                        
                        var response = await DataService.GetNasaApod();
                        if (response != null)
                        {
                            Apod = response;
                        }
                    }
                    else if (val.Equals("EPIC"))
                    {
                        var response = await DataService.GetNasaEpic();
                        if (response != null)
                        {
                            Epics = new ObservableCollection<EpicDto>(response);
                        }
                    }
                    else if (val.Equals("MARS"))
                    {
                        OnPropertyChanged(nameof(IsMars));
                        // set as default
                        IsMarsByCamera = true;
                        MarsPhotos?.Clear();
                        CameraTypes = new ObservableCollection<CameraTypeVm>(GenerateTypesList());
                        await ProcessSelectCamera(CameraTypes?.FirstOrDefault());

                        // get camera template as default
                        //CurrentTemplate = new ControlTemplate(typeof(MarsByCamera));

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

        private async Task GetMarsPhotosByDate(string date)
        {
            try
            {
                IsBusy = true;
                var photos = new List<MarsPhoto>();
                var mars = await DataService.GetMarsDataByDate(date);
                if (mars != null && mars.photos?.Count > 20)
                    photos = mars.photos.Take(20).ToList();
                else
                    photos = mars.photos.ToList();

                MarsPhotos = new ObservableCollection<MarsPhoto>(photos);
                OnPropertyChanged(nameof(Mars));
                OnPropertyChanged(nameof(MarsPhotos));
            }
            catch (Exception ex)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        private List<CameraTypeVm> GenerateTypesList()
        {
            return new List<CameraTypeVm>()
            {
                new CameraTypeVm
                {
                    Type = "FHAZ"
                },
                new CameraTypeVm
                {
                    Type = "RHAZ"
                },
                new CameraTypeVm
                {
                    Type = "MAST"
                },
                new CameraTypeVm
                {
                    Type = "CHEMCAM"
                },
                new CameraTypeVm
                {
                    Type = "MAHLI"
                },
                new CameraTypeVm
                {
                    Type = "MARDI"
                },
                new CameraTypeVm
                {
                    Type = "NAVCAM"
                }
            };
        }

        #endregion
    }
}
