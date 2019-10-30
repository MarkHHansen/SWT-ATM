using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Logger
{
    public class LogFile : ILogger
    {
        public LogFile()
        {
            MakeFolder();
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