using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Exceptions
{
    public class CabNotAvailableException : Exception
    {
        public CabNotAvailableException(string message) : base(message)
        {
        }
    }
}
