using HelloMauiApp.Interfaces;
using HelloMauiApp.Models;
using Newtonsoft.Json;

namespace HelloMauiApp.Services
{
    public class DataService : IDataService
    {
        private readonly INetworkService _networkService;
        public DataService(INetworkService networkService)
        {
            _networkService = networkService;

        }

        public async Task<MarsDto> GetMarsDataByCameraType(string cameraType)
        {
            //var result = await _networkService.ProcessApi(x => x.GetMarsByCamera(cameraType));

            //return result;

            try
            {
                var result = new MarsDto();

                var uri = new Uri($"{AppSettings.Constants.BaseApi}/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&camera={cameraType}&api_key=x5XFUSsKp0IdLjW16D9HPVKq2cpwpzZapI4uhwwZ");

                var request = System.Net.WebRequest.Create(uri);
                request.Method = "GET";
                var response = await request.GetResponseAsync();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        line = reader.ReadLine();
                        result = JsonConvert.DeserializeObject<MarsDto>(line);
                    }
                }
                response.Close();
                return result;

            }
            catch (JsonException jsEx)
            {
                Application.Current.Dispatcher.Dispatch(() => Application.Current.MainPage.DisplayAlert("Error", jsEx.Message, "Ok"));
                return new MarsDto();
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Dispatch(() => Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok"));
                return new MarsDto();
            }
        }

        public async Task<MarsDto> GetMarsDataByDate(string date)
        {
            //var result = await _networkService.ProcessApi(x => x.GetMarsByDate(date));

            //return result;

            try
            {
                var result = new MarsDto();

                var uri = new Uri($"{AppSettings.Constants.BaseApi}/mars-photos/api/v1/rovers/curiosity/photos?earth_date={date}&api_key=x5XFUSsKp0IdLjW16D9HPVKq2cpwpzZapI4uhwwZ");

                var request = System.Net.WebRequest.Create(uri);
                request.Method = "GET";
                var response = await request.GetResponseAsync();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        line = reader.ReadLine();
                        result = JsonConvert.DeserializeObject<MarsDto>(line);
                    }
                }
                response.Close();
                return result;

            }
            catch (JsonException jsEx)
            {
                Application.Current.Dispatcher.Dispatch(() => Application.Current.MainPage.DisplayAlert("Error", jsEx.Message, "Ok"));
                return new MarsDto();
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Dispatch(() => Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok"));
                return new MarsDto();
            }
        }

        public async Task<ApodDto> GetNasaApod()
        {
            try
            {
                var result = new ApodDto();

                //var result = await _networkService.ProcessApi(x => x.GetApod());

                var uri = new Uri($"{AppSettings.Constants.BaseApi}/planetary/apod?api_key=x5XFUSsKp0IdLjW16D9HPVKq2cpwpzZapI4uhwwZ");

                var request = System.Net.WebRequest.Create(uri);
                request.Method = "GET";
                var response = await request.GetResponseAsync();
                using (Stream stream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string line = "";
                        line = reader.ReadLine();
                        result = JsonConvert.DeserializeObject<ApodDto>(line);
                    }
                }
                response.Close();
                return result;

            }
            catch(JsonException jsEx)
            {
                Application.Current.Dispatcher.Dispatch(() => Application.Current.MainPage.DisplayAlert("Error", jsEx.Message, "Ok"));
                return new ApodDto();
            }
            catch (Exception ex)
            {
                Application.Current.Dispatcher.Dispatch(() => Application.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok"));
                return new ApodDto();
            }
           
        }

        public async Task<List<EpicDto>> GetNasaEpic()
        {
            var result = await _networkService.ProcessApi(x => x.GetEpic());

            return result;
        }
    }
}
