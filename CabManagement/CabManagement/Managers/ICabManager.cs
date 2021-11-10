using CabManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Managers
{
    public interface ICabManager
    {
        void RegisterCab(Cab cab);

        Cab GetCab(string cabId);

        List<Cab> ListCabs(string state);

        void UpdateCabLocation(string cabId, string location);

        void UpdateCabState(string cabId);
    }
}
