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


    }
}
