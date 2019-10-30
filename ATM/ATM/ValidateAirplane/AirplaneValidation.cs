using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.Converter;
using AirTrafficMonitor.OutputValidation;
using AirTrafficMonitor.Separation;
using ATM.ValidateAirplane;

namespace AirTrafficMonitor.AirplaneValidation
{
    class AirplaneValidation
    {
        private IAirplaneValidation _receiver;
        private List<Airplane> Validated;
        private IAirspace _airspace;

        public event EventHandler<LogSeperationEventArgs> LogSeperationEvent;
        public event EventHandler<PlaneConditionCheckedEventArgs> PlaneConditionChecked;

        public AirplaneValidation(IAirplaneValidation receiver)
        {
            this._receiver = receiver;

            this._receiver.ValidationEvent += Validate;
        }

        private void Validate(object s, ValidationEventArgs e)
        {
            Validated = e.PlanesToValidate;
            int[] stats = _airspace.getAirspaceLimits();

            foreach (Airplane data in e.PlanesToValidate)
            {
                List<Tracks> temp = data._tracks;

                if (stats[0] > temp[0]._xCoordiante && stats[1] < temp[0]._xCoordiante)
                {
                    if (stats[2] > temp[0]._yCoordiante && stats[3] < temp[0]._yCoordiante)
                    {
                        if (stats[4] > temp[0]._Altitude && stats[5] < temp[0]._Altitude)
                        {
                            Validated.Add(data);
                        }
                    }
                }
            }

            if (Validated != e.PlanesToValidate)
            {
                OnCheckSeperationCondition(new PlaneConditionCheckedEventArgs(Validated), new LogSeperationEventArgs(Validated));
            }
        }

        protected virtual void OnCheckSeperationCondition(PlaneConditionCheckedEventArgs epc, LogSeperationEventArgs els)
        {
            PlaneConditionChecked?.Invoke(this, epc);
            LogSeperationEvent?.Invoke(this, els);
        }

    }
}
