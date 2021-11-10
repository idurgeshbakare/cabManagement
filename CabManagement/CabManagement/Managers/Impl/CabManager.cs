using CabManagement.Domain;
using CabManagement.Services;
using System.Collections.Generic;
using System.Linq;

namespace CabManagement.Managers.Impl
{
    public class CabManager : ICabManager
    {
        private readonly ICabService cabService;
        private readonly ILocationService locationService;

        public CabManager(ICabService cabService/*, ILocationService locationManager*/)
        {
            this.cabService = cabService;
            //this.locationService = locationManager;
        }

        public void RegisterCab(Cab cab)
        {
            // Register the Cab
            cabService.RegisterCab(cab);

            // Along with regitrating Cab, also added location
            //locationService.RegisterCityForCabService(cab.Location);
        }

        public Cab GetCab(string cabId)
        {
            return cabService.GetCab(cabId);
        }

        public List<Cab> ListCabs(string state)
        {
            return cabService.ListCabs(state);
        }

        public void UpdateCabLocation(string cabId, string location)
        {
            cabService.UpdateCabLocation(cabId, location);
        }

        public void UpdateCabState(string cabId)
        {
            cabService.UpdateCabState(cabId);
        }
    }
}
