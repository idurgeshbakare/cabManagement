using CabManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Managers
{
    public interface IRiderManager
    {
        void Register(Rider rider);

        Rider GetRider(string riderId);
    }
}
