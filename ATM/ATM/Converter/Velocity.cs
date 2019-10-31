using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Converter
{
    public class Velocity : IVelocity
    {
        public double CalculateVolocity(double x1, double x2, double y1, double y2, DateTime oldDateTime, DateTime newDateTime)
        {
            double deltaX = x1 - x2;
            double deltaY = y1 - y2;

            double Timespan = deltaTime(oldDateTime, newDateTime);

            double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
            double velocity = distance / Timespan;

            return velocity;

        }

        public double deltaTime(DateTime oldDateTime, DateTime newDateTime)
        {
            TimeSpan span = newDateTime.Subtract(oldDateTime);

            return span.TotalSeconds;
        }
    }
   
}
