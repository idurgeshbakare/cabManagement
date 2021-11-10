using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.Domain;
using CabManagement.Services;

namespace CabManagement.Managers.Impl
{
    public class RiderManager : IRiderManager
    {
        private readonly IRiderService riderService;

        public RiderManager(IRiderService riderService)
        {
            this.riderService = riderService;
        }

        public Rider GetRider(string riderId)
        {
            return riderService.GetRider(riderId);
        }

        public void Register(Rider rider)
        {
            riderService.Register(rider);

        }
    }
}
