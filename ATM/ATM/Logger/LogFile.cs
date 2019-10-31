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
    public class LogFile 
    {
        private System.IO.StreamWriter file;
        public string Collision { get; set; }
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

        void MakeFile()
        {
            if (!Directory.Exists(@"..\logs\Logs.txt"))
            {
                file = File.AppendText(@"C:..\Logs\Logs.txt");
            }
        }

        public void MakeFolder()
        {
            if (!Directory.Exists(@"..\logs"))
            {
                Directory.CreateDirectory(@"..\logs");
            }
        }

    }
}