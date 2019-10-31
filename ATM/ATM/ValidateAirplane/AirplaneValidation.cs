﻿using System;
using System.Collections.Generic;
using ATM.Converter;
using ATM.Separation;
using ATM.OutputValidation_;

namespace ATM.ValidateAirplane
{
    public class AirplaneValidation : IAirplaneValidation
    {
        private IConvertFilter _receiver;
        private List<Airplane> Validated = new List<Airplane>();
        private Airspace _airspace = new Airspace();

        public event EventHandler<ValidationEventArgs> ValidationEvent;
        //public event EventHandler<LogSeperationEventArgs> LogSeperationEvent;
        //public event EventHandler<PlaneConditionCheckedEventArgs> PlaneConditionChecked;

        public AirplaneValidation(IConvertFilter receiver)
        {
            this._receiver = receiver;

            this._receiver.ConvertedDataEvent += _receiver_ConvertedDataEvent;
        }

        private void _receiver_ConvertedDataEvent(object sender, ConvertEventArgs e)
        {

            List<Airplane> temp = e.ConvertedData;
            int[] stats = _airspace.getAirspaceLimits();

            foreach (var data in temp)
            {

                if (stats[0] > data._Altitude && stats[1] < data._Altitude)
                {
                    if (stats[2] > data._yCoordiante && stats[3] < data._yCoordiante)
                    {
                        if (stats[4] > data._xCoordiante && stats[5] < data._xCoordiante)
                        {
                            Validated.Add(data);
                        }
                    }
                }
            }


            OnCheckSeperationCondition(new ValidationEventArgs(Validated));

        }

        //private void Validate(object s, ValidationEventArgs e)
        //{
        //    Validated = e.PlanesToValidate;
        //    int[] stats = _airspace.getAirspaceLimits();

        //    foreach (Airplane data in e.PlanesToValidate)
        //    {


        //        if (stats[0] > data._xCoordiante && stats[1] < data._xCoordiante)
        //        {
        //            if (stats[2] > data._yCoordiante && stats[3] < data._yCoordiante)
        //            {
        //                if (stats[4] > data._Altitude && stats[5] < data._Altitude)
        //                {
        //                    Validated.Add(data);
        //                }
        //            }
        //        }
        //    }

        //    if (Validated != e.PlanesToValidate)
        //    {
        //        OnCheckSeperationCondition(new PlaneConditionCheckedEventArgs(Validated), new LogSeperationEventArgs(Validated));
        //    }
        //}

        protected virtual void OnCheckSeperationCondition(ValidationEventArgs event_)
        {
            ValidationEvent?.Invoke(this, event_);
            //Console.WriteLine("tis");
        }


    }
}
