using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Converter
{
    public class Airplane : IAirplane
    {
        public Airplane(/*string tag, double velocity, int course, List<Tracks> tracks, bool SeperationCodition*/)
        {
            //_tag = tag;
            //_velocity = velocity;
            //_compasCourse = course;
            //_tracks = tracks;
            //_seperationCodition = SeperationCodition;
        }
        public string _tag
        {
            get => _tag;
            set => _tag = value;
        }

        public double _velocity
        {
            get => _velocity;
            set => _velocity = value;
        }

        public double _compasCourse
        {
            get => _compasCourse;
            set => _compasCourse = value;
        }

        public bool _seperationCodition
        {
            get => _seperationCodition;
            set => _seperationCodition = value;
        }

        public double _xCoordiante { get; set; }

        public double _yCoordiante { get; set; }

        public double _Altitude { get; set; }

        public DateTime _Time { get; set; }

    }
}