using CabManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.CabLocator
{
    public interface ICabLocatorStrategy
    {
        Cab LocateCab(List<Cab> avilableCabs);
    }
}
