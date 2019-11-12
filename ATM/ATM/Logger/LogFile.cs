using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Separation;

namespace ATM.Logger
{
    
    public class LogFile : ILogger
    {
        private System.IO.StreamWriter file;
        public List<string> Collision { get; set; }
        public LogFile()
        {
        }

        public void LogCollision(List<string> messages)
        {
            MakeFolder();
            MakeFile();
            for (int i = 0; i < messages.Count; i++)
            {
                file.WriteLine(messages[i]);
                Console.WriteLine(messages[i]);
                //Collision = messages[i]; 
            }

            file.Close();
        }

        public void MakeFile()
        {
            if (!Directory.Exists(@"..\Logs\Logs.txt"))
            {
                file = File.AppendText(@"C:..\Logs\Logs.txt");
            }
        }

        public void MakeFolder()
        {
            if (!Directory.Exists(@"..\Logs"))
            {
                Directory.CreateDirectory(@"..\Logs");
            }
        }

    }
}