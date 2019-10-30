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
            List<Tracks> tracks = new List<Tracks>();

            foreach (var data in this.transponderData)
            {
                string[] dataStrings = data.Split(';');
                Tracks track = new Tracks();

                track.Tag
            }

        }

        protected virtual void OnConvertedDataEvent(ConvertEventArgs e)
        {
            ConvertedDataEvent?.Invoke(this, e);
        }
    }
}