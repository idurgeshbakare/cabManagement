using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.Domain;

namespace CabManagement.Services.Impl
{
    public class TripService : ITripService
    {
        private static readonly IDictionary<string, List<Trip>> tripMap = new Dictionary<string, List<Trip>>();

        public void AddTrip(string cabId, Trip trip)
        {
            if (!tripMap.ContainsKey(cabId))
            {
                tripMap.Add(cabId, new List<Trip>());
            }

            tripMap[cabId].Add(trip);
        }


        public List<Trip> GetTripHistory(string cabId)
        {
            if (!tripMap.ContainsKey(cabId))
            {
                return new List<Trip>();
            }
            return tripMap[cabId];
        }
    }
}
