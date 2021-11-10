using CabManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Services
{
    public interface ITripService
    {

        void AddTrip(string CabId, Trip trip);
    }
}
