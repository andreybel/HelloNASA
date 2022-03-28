using HelloMauiApp.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiApp.Interfaces
{
    public interface INasaApi
    {
        [Get("/planetary/apod?api_key=x5XFUSsKp0IdLjW16D9HPVKq2cpwpzZapI4uhwwZ")]
        Task<ApodDto> GetApod();

        [Get("/EPIC/api/natural?api_key=x5XFUSsKp0IdLjW16D9HPVKq2cpwpzZapI4uhwwZ")]
        Task<List<EpicDto>> GetEpic();

        [Get("/mars-photos/api/v1/rovers/curiosity/photos?sol=1000&camera={cameraType}&api_key=x5XFUSsKp0IdLjW16D9HPVKq2cpwpzZapI4uhwwZ")]
        Task <MarsDto> GetMars(string cameraType);

    }
}
