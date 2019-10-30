using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AirplaneValidation;
using AirTrafficMonitor.Converter;

namespace AirTrafficMonitor.Separation
{
    public class CheckSeparationCondition : ICheckSeparationCondition
    {
        private int _minVertical = 300;

        private int _minHorizontal = 5000;

        //private List<Separation> _conditions;
        public event EventHandler<PlaneConditionCheckedEventArgs> PlaneConditionChecked;
        public List<Airplane> _currentAirplane { get; set; }

        public CheckSeparationCondition(IAirplaneValidation plane)
        {
            plane.ValidationEvent += HandleAirplaneValidationEvent;
        }

        private void HandleAirplaneValidationEvent(object sender, ValidationEventArgs e)
        {
            _currentAirplane = e.PlanesToValidate;
        }

        public void Detect()
        {
            for (int i = 0; i < _currentAirplane.Count; i++)
            {
                for (int j = i + 1; j < _currentAirplane.Count; j++)
                {
                    Airplane plane1 = _currentAirplane[i];
                    Airplane plane2 = _currentAirplane[j];
                    var time = DateTime.Compare(plane1.Time, plane2.Time) < 0 ? plane1.Time : plane2.Time;

                }

            }
        }

        public bool CheckForCollission(Tracks airplane1, Tracks airplane2)
        {
            double yPow = (Math.Pow(Math.Abs(airplane1._yCoordiante - airplane2._yCoordiante), 2));
            double xPow = (Math.Pow(Math.Abs(airplane1._xCoordiante - airplane2._xCoordiante), 2));
            double distance = Math.Sqrt(xPow + yPow);

            int altitude = (Math.Abs(airplane1._Altitude - airplane2._Altitude));

            if (altitude < _minVertical && distance < _minHorizontal) 
                return true;
            
            return false;
        }
    }
}