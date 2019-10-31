using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Converter
{
    public interface ICompassCourse
    {
        double CalculateCompassCourse(double x1, double y1, double x2, double y2);
    }
}