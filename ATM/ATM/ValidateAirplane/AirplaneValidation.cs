using System;
using System.Collections.Generic;
using ATM.Converter;
using ATM.Separation;
using ATM.OutputValidation_;

namespace ATM.ValidateAirplane
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
                

                if (stats[0] > data._xCoordiante && stats[1] < data._xCoordiante)
                {
                    if (stats[2] > data._yCoordiante && stats[3] < data._yCoordiante)
                    {
                        if (stats[4] > data._Altitude && stats[5] < data._Altitude)
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
