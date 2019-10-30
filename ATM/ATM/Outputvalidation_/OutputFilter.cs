using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATM.OutputValidation
{
    class OutputFilter
    {
        private ILogger _consoleLogger;
        private ILogger _ILogger;
        private List<Airplane> _oldplane;


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



        public void CleanUp()
        {

        }

        public List<Airplane> CurrentAirplanes { get; set; }

        public OutputFilter(IAirplaneValidation airplaneValidation)
        {
            airplaneValidation.ValidationEvent += HandleValidationEvent;
        }

        private void HandleValidationEvent(object sender, ValidationEventArgs e)
        {
            CurrentAirplanes = e.PlanesToValidate;
        }
    }
}
