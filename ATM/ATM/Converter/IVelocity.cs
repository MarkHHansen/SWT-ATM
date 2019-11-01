using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Converter
{
    public interface IVelocity
    {
        double CalculateVolocity(double x1, double x2, double y1, double y2, DateTime oldDateTime, DateTime newDateTime);
    }
}