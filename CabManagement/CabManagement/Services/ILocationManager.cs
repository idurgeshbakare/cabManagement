using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Services
{
    public interface ILocationService
    {
        void RegisterCityForCabService(string cityLocation);
    }
}
