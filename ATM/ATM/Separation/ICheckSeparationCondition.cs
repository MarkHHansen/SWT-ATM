using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Separation
{
    public interface ICheckSeparationCondition
    {
        event EventHandler<PlaneConditionCheckedEventArgs> PlaneConditionChecked; 
    }
}
