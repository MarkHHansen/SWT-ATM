using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ATM.ValidateAirplane
{
    public class Airspace : IAirspace
    {
        private int _xhigh, _xlow;
        private int _yhigh, _ylow;
        private int _zLow, _zHigh;

        public Airspace()
        {
            _xhigh = 90000;
            _xlow = 10000;
            _yhigh = 90000;
            _ylow = 10000;
            _zLow = 500;
            _zHigh = 20000;
        }

        public int[] getAirspaceLimits()
        {
            int[] temp = new int[6];
            temp[0] = _zHigh;
            temp[1] = _zLow;
            temp[2] = _yhigh;
            temp[3] = _ylow;
            temp[4] = _xhigh;
            temp[5] = _xlow;
            return temp;
        }
    }
}