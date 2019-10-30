using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficMonitor.Converter
{
    public class ConvertFilter : IConvertFilter
    {

        //event Handler for transponder receiver

        private List<string> transponderData = new List<string>();

        private ITransponderReceiver _receiver;

        ConvertFilter(ITransponderReceiver receiver)
        {
            this._receiver = receiver;

            this.receiver.TransponderDataReady += ReceiverOnTransponderDataReady;
        }

        private void ReceiverOnTransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            transponderData = e.TransponderData;
            convertdata(transponderData);
        }


        //event Source

        private List<Airplane> oldAirplane = new List<Airplane>();
        private List<Tracks> oldTracks = new List<Tracks>();
        public event EventHandler<ConvertEventArgs> ConvertedDataEvent;

        public void convertdata(List<string> transponderData)
        {
            List<Airplane> airplanes = new List<Airplane>();

            foreach (var data in this.transponderData)
            {
                string[] dataStrings = data.Split(';');
                Tracks track = new Tracks();
                Airplane airplane = new Airplane();

                airplane._tag = dataStrings[0];

                track._xCoordiante = Convert.ToDouble(dataStrings[1]);
                    
                track._yCoordiante = Convert.ToDouble(dataStrings[2]);

                track._Altitude = Convert.ToDouble(dataStrings[3]);

                track._Time = DateTime.ParseExact(dataStrings[4], "yyyy-mm-dd-hh-mm-ss-ff", null);

                airplane._tracks.Add(track);

            }

        }

        protected virtual void OnConvertedDataEvent(ConvertEventArgs e)
        {
            ConvertedDataEvent?.Invoke(this, e);
        }
    }
}