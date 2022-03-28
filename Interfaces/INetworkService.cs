using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMauiApp.Interfaces
{
    public interface INetworkService
    {
        Task<T> ProcessApi<T>(Func<INasaApi, Task<T>> func);

    }
}
