using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.Converter
{
    public interface IConvertFilter
    {
        event EventHandler<ConvertEventArgs> ConvertedDataEvent;
    }
}