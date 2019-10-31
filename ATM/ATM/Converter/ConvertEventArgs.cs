using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Converter
{
    public class ConvertEventArgs : EventArgs
    {
        public List<Airplane> ConvertedData { get; set; }

        public ConvertEventArgs(List<Airplane> convertedData)
        {
            ConvertedData = convertedData;
        }
    }
}