using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Converter
{
    public class ConvertEventArgs : EventArgs
    {
        public ConvertEventArgs(List<Airplane> convertedData) { }

        public List<Airplane> ConvertedData { get; set; }
    }
}