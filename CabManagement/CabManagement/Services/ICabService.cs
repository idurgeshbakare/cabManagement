using CabManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Services
{
    public interface ICabService
    {
        void RegisterCab(Cab cab);

        void UpdateCabLocation(string cabId, string location);

        void UpdateCabState(string cabId);

        Cab GetCab(string cabId);

        List<Cab> ListCabs(string state);

        List<Cab> GetAllAvailableCabByLocation(string location);
    }
}
