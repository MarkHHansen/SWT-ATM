using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;

namespace ATM.Separation
{
    public class PlaneConditionCheckedEventArgs : EventArgs
    {
        public PlaneConditionCheckedEventArgs(List<Airplane> planeconditionchecked)
        {
            this.PlaneConditionChecked = planeconditionchecked;
        }
        public List<Airplane> PlaneConditionChecked { get; set; }
    };
}
