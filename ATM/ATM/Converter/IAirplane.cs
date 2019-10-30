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

        List<Tracks> _tracks { get; set; }

        bool _seperationCodition { get; set; }
    }
}