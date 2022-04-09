using HelloMauiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiApp.Interfaces
{
    public interface IDataService
    {
        Task<ApodDto> GetNasaApod();
        Task<List<EpicDto>> GetNasaEpic();

        Task<MarsDto> GetMarsDataByCameraType(string cameraType);
        Task<MarsDto> GetMarsDataByDate(string date);
    }
}
