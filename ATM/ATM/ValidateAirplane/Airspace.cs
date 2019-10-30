using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AirTrafficMonitor.AirplaneValidation
{
    public class Airspace : IAirspace
    {
        private int _xhigh, _xlow;
        private int _yhigh, _ylow;
        private int _zLow, _zHigh;

        Airspace()
        {
            _xhigh = 90000;
            _xlow = 10000;
            _yhigh = 90000;
            _ylow = 10000;
            _zLow = 500;
            _zHigh = 20000;
        }

        int[] IAirspace.getAirspaceLimits()
        {
            int[] temp = new int[5];
            temp[0] = _xhigh;
            temp[1] = _xlow;
            temp[2] = _yhigh;
            temp[3] = _ylow;
            temp[4] = _zHigh;
            temp[5] = _zLow;
            return temp;
        }
    }
}