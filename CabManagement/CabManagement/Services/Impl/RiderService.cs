using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.Domain;
using CabManagement.Exceptions;

namespace CabManagement.Services.Impl
{
    
    public class RiderService : IRiderService
    {
        private static IDictionary<string, Rider> riderMap = new Dictionary<string, Rider>();


        public void Register(Rider rider)
        {
            if (!riderMap.ContainsKey(rider.RiderId))
            {
                riderMap[rider.RiderId] = rider;
            }
            else
            {
                throw new RiderAlreadyExists($"Rider with id '{rider.RiderId}' already exists");
            }
        }


        public Rider GetRider(string riderId)
        {
            if (!riderMap.ContainsKey(riderId))
            {
                throw new RiderDoesNotExists($"Rider with id '{riderId}' does not exists");
            }

            return riderMap[riderId];

        }
    }
}
