using HelloMauiApp.Interfaces;
using HelloMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<ApodDto> GetNasaApod()
        {
            var result = await _networkService.ProcessApi(x => x.GetApod());

            return result;
        }
    }
}
