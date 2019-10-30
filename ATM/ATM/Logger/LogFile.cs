﻿using System;
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
        private System.IO.StreamWriter file;
        public string Collision { get; set; }
        public LogFile()
        {
            MakeFolder();
            MakeFile();
        }

        public void LogCollision(List<string> messages)
        {
            for (int i = 0; i < messages.Count; i++)
            {
                file.WriteLine(messages[i]);
                Collision = messages[i]; 
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