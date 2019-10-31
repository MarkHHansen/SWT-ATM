using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;
using ATM.Separation;
using ATM.Converter;
using ATM.ValidateAirplane;
using ATM.Logger;

namespace ATM
{
    class Program
    {
        

        static void Main(string[] args)
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();


            
        }

    }
}
