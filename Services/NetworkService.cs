using HelloMauiApp.Interfaces;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiApp.Services
{
    public class NetworkService : INetworkService
    {
        private INasaApi _nasaApi;

        public NetworkService()
        {
            SetupApi();
        }

        public bool IsConnected => Connectivity.NetworkAccess == NetworkAccess.Internet;

        private void SetupApi()
        {
            var client = new HttpClient() { BaseAddress = new Uri(AppSettings.Constants.BaseApi) };
            _nasaApi = RestService.For<INasaApi>(client);
        }

        public Task<T> ProcessApi<T>(Func<INasaApi, Task<T>> func)
        {
            if (IsConnected)
            {
                return func(_nasaApi);
            }

            throw new Exception();
        }
    }
}
