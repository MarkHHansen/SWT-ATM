using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Converter;

namespace AirTrafficMonitor.Logger
{
    public interface ILogger
    {
        void PrintCollision();
        void PrintAirplanes(List<string> airplanes);
    }
}
