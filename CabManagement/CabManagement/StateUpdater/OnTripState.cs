using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.Domain;

namespace CabManagement.StateUpdater
{
    public class OnTripState : IState
    {
        public void ChangeState(Cab cab)
        {
            if (cab.State == Enums.TripState.ON_TRIP.ToString())
            {
                cab.State = Enums.TripState.IDLE.ToString();
                cab.CurrentTrip = null;
                cab.TripState = new IDLEState();
            }
        }
    }
}
