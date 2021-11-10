using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.Exceptions
{
    public class CabDoesNotExist : Exception
    {
        public CabDoesNotExist(string message) : base(message)
        {
        }
    }
}
