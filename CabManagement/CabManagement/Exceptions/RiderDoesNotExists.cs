using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Exceptions
{
    public class RiderDoesNotExists : Exception
    {
        public RiderDoesNotExists(string message) : base(message)
        {
        }
    }
}
