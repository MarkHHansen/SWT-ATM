using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.ValidateAirplane;
using ATM.Converter;
using ATM.Logger;

namespace ATM.OutputValidation_
{
    public class OutputFilter
    {


        public IAirplaneValidation _airplaneValidation;
        ConsoleLogger consolelogger = new ConsoleLogger();


        //public event EventHandler<LogSeperationEventArgs> LogSeperationEvent;


        //public void LogPlanes(List<Airplane> ap)
        //{
        //    if (ap != _oldplane)
        //    {
        //        OnLogSeperationEventArgs(new LogSeperationEventArgs(_oldplane) { planesToLog = ap });
        //        _oldplane = ap;
        //    }
        //}

        //protected virtual void OnLogSeperationEventArgs(LogSeperationEventArgs e)
        //{
        //    LogSeperationEvent?.Invoke(this, e);
        //}

        //  public List<Airplane> CurrentAirplanes { get; set; }

        public OutputFilter(IAirplaneValidation airplaneValidation)
        {
            this._airplaneValidation = airplaneValidation;

            _airplaneValidation.ValidationEvent += HandleValidationEvent;
        }

        private void HandleValidationEvent(object sender, ValidationEventArgs e)
        {
            List<Airplane> CurrentAirplanes = e.PlanesToValidate;
            consolelogger.PrintAirplanes(CurrentAirplanes);
        }
    }
}
