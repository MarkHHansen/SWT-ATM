using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Separation;

namespace AirTrafficMonitor.Logger
{
    public class LogFile : ILogger
    {
        private SeparationCondition separation; 
        public LogFile()
        {
            MakeFolder();
        }

        public void LogSeparationCondition()
        {
            System.IO.StreamWriter file = File.AppendText(@"C:..\Logs\Logs.txt");
            {
                file.WriteLine($"{separation.Time}: between: {separation.Pair}\t and {sep.Tag2}");
            }
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