using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;

namespace ATM.Logger
{
    public class ConsoleLogger : ILogger
    {
        private LogFile sep; 
        public void PrintAirplanes(List<Airplane> airplanes)
        {
            foreach (var plane in airplanes)
            {
                Console.WriteLine(plane);

            }
        }

        public void PrintCollision()
        {
            Console.WriteLine(@"Collision: " + sep.Collision);
        }
    }
}
