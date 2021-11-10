using CabManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Managers
{
    public interface IBookingManager
    {
        void BookCab(string riderId, Trip trip);

    }
}
