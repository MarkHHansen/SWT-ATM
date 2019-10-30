using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Converter
{
    public class ConvertEventArgs : EventArgs
    {
        public ConvertEventArgs(List<Tracks> convertedData) { }

        public List<Tracks> ConvertedData { get; set; }
    }
}