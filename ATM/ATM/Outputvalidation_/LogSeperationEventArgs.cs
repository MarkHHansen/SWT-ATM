using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;

namespace ATM.OutputValidation
{
    public class LogSeperationEventArgs : EventArgs
    {
        public LogSeperationEventArgs(List<Airplane> ap)
        {


        }


        public List<Airplane> planesToLog
        {
            get;
            set;
        }

    }
}
