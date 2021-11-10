using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.CabLocator;
using CabManagement.Domain;
using CabManagement.Enums;
using CabManagement.Exceptions;
using CabManagement.Services;

namespace CabManagement.Managers.Impl
{
    public class BookingManager : IBookingManager
    {
        private readonly ICabService cabService;
        private readonly ITripService tripService;
        private readonly ICabLocatorStrategy cabLocatorStrategy;
        private readonly IRiderService riderService;

        public BookingManager(ICabService cabService, ITripService tripService, ICabLocatorStrategy cabLocatorStrategy, IRiderService riderService)
        {
            this.cabService = cabService;
            this.tripService = tripService;
            this.cabLocatorStrategy = cabLocatorStrategy;
            this.riderService = riderService;
        }
    
        public void BookCab(string riderId, Trip trip)
        {
            // validate the rider
            riderService.GetRider(riderId);

            var cabs = cabService.GetAllAvailableCabByLocation(trip.StartingLocation);
            if(!cabs.Any())
            {
                throw new CabNotAvailableException($"Sorry! Cab not avilable form location '{trip.StartingLocation}'");
            }

            var cab = cabLocatorStrategy.LocateCab(cabs);

            //Mark Cab availability and Set the current trip for Cab
            cab.CurrentTrip = trip;
            cab.TripState.ChangeState(cab);
            cab.LastBookingDate = DateTime.UtcNow.Ticks;

            // Add trip to Cab trip history
            tripService.AddTrip(cab.CabId, trip);

        }
    }
}
