using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;

namespace ATM.Logger
{
    public interface ILogger
    {
        void PrintAirplanes(List<Airplane> airplanes);
    }
}
