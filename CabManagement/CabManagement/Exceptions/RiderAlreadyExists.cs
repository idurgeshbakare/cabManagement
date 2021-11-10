using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Exceptions
{
    public class RiderAlreadyExists : Exception
    {
        public RiderAlreadyExists(string message) : base(message)
        {
        }
    }
}
