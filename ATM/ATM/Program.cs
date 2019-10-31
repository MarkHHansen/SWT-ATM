using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using AirTrafficMonitor.Separation;
using AirTrafficMonitor.Converter;
using AirTrafficMonitor.AirplaneValidation;
using AirTrafficMonitor.Logger;

namespace AirTrafficMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
        }

    }
}
