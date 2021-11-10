using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabManagement.Domain;

namespace CabManagement.CabLocator
{
    public class CabLocatorByIdlTimeStrategy : ICabLocatorStrategy
    {
        public Cab LocateCab(List<Cab> avilableCabs)
        {
            avilableCabs.Sort((cab1, cab2) => cab1.LastBookingDate.CompareTo(cab2.LastBookingDate));
            return avilableCabs.First();
        }
    }
}
