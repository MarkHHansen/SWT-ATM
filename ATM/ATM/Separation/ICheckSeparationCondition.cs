using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;

namespace ATM.Separation
{
    public interface ICheckSeparationCondition
    {
        //event EventHandler<PlaneConditionCheckedEventArgs> PlaneConditionChecked; 
        void DetectCollisions(List<Airplane> valAirplanes);
    }
}
