using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;
using ATM.ValidateAirplane;
using ATM.Logger;
using ATM.OutputValidation_;
using ATM.Separation;
using TransponderReceiver;

namespace ATM
{
    public class Client
    {
        private ConvertFilter _convertFilter;
        private AirplaneValidation _airplaneValidation;
        private SeparationCondition _separationCondition;
        private OutputFilter _outputFilter;
        

        public Client()
        {
            var receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            _convertFilter = new ConvertFilter(receiver, new CompasCourse(), new Velocity());
            _airplaneValidation = new AirplaneValidation(_convertFilter);
            _outputFilter = new OutputFilter(_airplaneValidation);
            _separationCondition = new SeparationCondition();

        }

}
