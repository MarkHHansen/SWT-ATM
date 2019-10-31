using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;

namespace ATM.Separation
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

        public bool Equals(SeparationCondition other)
        {
            if (string.Equals(this.Pair.Item1._tag, other.Pair.Item1._tag) &&
                string.Equals(this.Pair.Item2._tag, other.Pair.Item2._tag))
            {
                return true;
            }

            return false;
        }
    }
}
