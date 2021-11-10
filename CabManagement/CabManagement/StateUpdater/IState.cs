using CabManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CabManagement.StateUpdater
{
    public interface IState
    {
        void ChangeState(Cab cab);
    }
}
