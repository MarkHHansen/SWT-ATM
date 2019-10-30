using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Converter;

namespace AirTrafficMonitor.Separation
{
    public class SeparationCondition
    {
        public DateTime Time { get; set; }

        public Tuple<Airplane, Airplane> Pair { get; set; }

        public SeparationCondition(DateTime time, Tuple<Airplane, Airplane> pair)
        {
            Time = time;
            Pair = pair;
        }
    }
}
