using System;
using System.Collections.Generic;
using System.Data;
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


        public OutputFilter(IAirplaneValidation airplaneValidation)
        {
            this._airplaneValidation = airplaneValidation;

            _airplaneValidation.ValidationEvent += HandleValidationEvent;
        }

        private void HandleValidationEvent(object sender, ValidationEventArgs e)
        {
            List<Airplane> CurrentAirplanes = e.PlanesToValidate;
            consolelogger.Clear();
            consolelogger.PrintAirplanes(CurrentAirplanes);
        }

    }
}
