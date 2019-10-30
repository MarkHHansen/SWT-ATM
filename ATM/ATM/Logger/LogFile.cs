using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Logger
{
    public class LogFile : ILogger
    {
        LogFile()
        {

        }
        public void Print(List<string> airplanes)
        {

        }

        public void LogSeparation()
        {

        }

        public void MakeFolder()
        {
            if (!System.IO.Directory.Exists(@"..\logs"))
            {
                System.IO.Directory.CreateDirectory(@"..\logs");
            }
        }

    }
}