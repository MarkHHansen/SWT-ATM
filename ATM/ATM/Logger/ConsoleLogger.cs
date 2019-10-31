using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Logger
{
    public class ConsoleLogger : ILogger
    {
        private LogFile sep; 
        public void PrintAirplanes(List<string> airplanes)
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
