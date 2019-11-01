using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TransponderReceiver;
using ATM.Separation;
using ATM.Converter;
using ATM.ValidateAirplane;
using ATM.Logger;

namespace ATM
{
    public class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            ConsoleLogger logger = new ConsoleLogger();

            while (true)
            {
                Thread.Sleep(201);
                
                
            }
        }
    }
}
