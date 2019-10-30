using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Converter
{
     public interface IAirplane
    {
        string _tag { get; set; }

        double _velocity { get; set; }

        double _compasCourse { get; set; }

        bool _seperationCodition { get; set; }

        double _xCoordiante { get; set; }

        double _yCoordiante { get; set; }

        double _Altitude { get; set; }

        DateTime _Time { get; set; }
    }
}