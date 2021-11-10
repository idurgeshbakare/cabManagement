using CabManagement.Enums;
using CabManagement.StateUpdater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Domain
{
    public class Cab
    {
        /// <summary>
        /// Represents unique Id for Cab
        /// </summary>
        public string CabId { get; set; }

        /// <summary>
        /// Name of Cab Driver
        /// </summary>
        public string DriverName { get; set; }

        /// <summary>
        /// Current Location of Cab
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Type of cab
        /// </summary>
        public string CabType { get; set; } = Enums.CabType.MINI.ToString();

        /// <summary>
        /// State of Cab : IDLE or ON_TRIP
        /// </summary>
        public string State { get; set; } = Enums.TripState.IDLE.ToString();

        public long LastBookingDate { get; set; }

        public Trip CurrentTrip{ get; set; }

        public IState TripState { get; set; } = new IDLEState();
    }
}
