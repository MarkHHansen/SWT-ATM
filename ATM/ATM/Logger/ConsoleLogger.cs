using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;

namespace ATM.Logger
{
    public class ConsoleLogger : IConLogger
    {
        public void PrintAirplanes(List<Airplane> airplanes)
        {
            foreach (var plane in airplanes)
            {
                Console.WriteLine($"Tag: {plane._tag}\t X-Position: {plane._xCoordiante}\t Y-Position: {plane._yCoordiante}\t Altitude: {plane._Altitude} m\t Timestamp: {plane._Time}\n" +
                                  $"Horizontal Velocity: {plane._velocity} m/s\t Current compass course: {plane._compasCourse} degrees\n");
                Console.WriteLine("\n");

            }
        }

        public void Clear()
        {
            Console.Clear();
        }
    }
}
