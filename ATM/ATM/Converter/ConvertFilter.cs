using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TransponderReceiver;

namespace ATM.Converter
{
    public class ConvertFilter : IConvertFilter
    {

        //event Handler for transponder receiver

        private List<string> transponderData = new List<string>();

        public ITransponderReceiver _receiver;
        private ICompassCourse _compassCourse;
        private IVelocity _volocity;

        public ConvertFilter(ITransponderReceiver receiver, ICompassCourse compassCourse, IVelocity velocity)
        {
            this._receiver = receiver;
            this._compassCourse = compassCourse;
            this._volocity = velocity;
            this._receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            transponderData = e.TransponderData;
            convertdata(transponderData);
        }


        //event Source

        private List<Airplane> oldAirplanes = new List<Airplane>();
        public event EventHandler<ConvertEventArgs> ConvertedDataEvent;

        public void convertdata(List<string> transponderData)
        {
            List<Airplane> airplanes = new List<Airplane>();

            foreach (var data in this.transponderData) //Hvorfor bliver der kaldt this.trandponderData i stedet for den som givet med som parameter?
            {
                string[] dataStrings = data.Split(';');

                Airplane airplane = new Airplane();

                airplane._tag = dataStrings[0];

                airplane._xCoordiante = Convert.ToDouble(dataStrings[1]);
                    
                airplane._yCoordiante = Convert.ToDouble(dataStrings[2]);

                airplane._Altitude = Convert.ToDouble(dataStrings[3]);

                airplane._Time = DateTime.ParseExact(dataStrings[4], "yyyyMMddHHmmssfff", CultureInfo.InvariantCulture);

                foreach (Airplane plane in oldAirplanes)
                {
                    if (airplane._tag == plane._tag)
                    {
                        airplane._velocity = _volocity.CalculateVolocity(plane._xCoordiante, airplane._xCoordiante,
                            plane._yCoordiante, airplane._yCoordiante, plane._Time, airplane._Time);
                        airplane._compasCourse = _compassCourse.CalculateCompassCourse(plane._xCoordiante,
                            plane._yCoordiante, airplane._xCoordiante, airplane._yCoordiante);

                        //plane._xCoordiante = airplane._xCoordiante;
                        //plane._yCoordiante = airplane._yCoordiante;
                        //plane._Time = airplane._Time;
                        //plane._Altitude = airplane._Altitude;
                    }
                }

                airplanes.Add(airplane);
            }

            //OnConvertedDataEvent(new ConvertEventArgs(oldAirplanes));
            OnConvertedDataEvent(new ConvertEventArgs(airplanes));
            oldAirplanes = airplanes;
        }

        protected virtual void OnConvertedDataEvent(ConvertEventArgs e)
        {
            ConvertedDataEvent?.Invoke(this, e);
        }

        public List<Airplane> GetOldAirplanes()
        {
            return oldAirplanes;
        }
    }
}