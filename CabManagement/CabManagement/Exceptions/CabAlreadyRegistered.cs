using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Exceptions
{
    public class CabAlreadyRegistered : Exception
    {
        public CabAlreadyRegistered(string message) : base(message)
        {
        }
    }
}
