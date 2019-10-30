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
        public event EventHandler<PlaneConditionCheckedEventArgs> PlaneConditionChecked;
        public List<Airplane> _currentAirplane { get; set; }
        private List<SeparationCondition> _conditions;

        public CheckSeparationCondition(IAirplaneValidation plane)
        {
            plane.ValidationEvent += HandleAirplaneValidationEvent;
        }

        private void HandleAirplaneValidationEvent(object sender, ValidationEventArgs e)
        {
            _currentAirplane = e.PlanesToValidate;
        }

        public void Detect(List<Tracks> temp)
        {
            for (int i = 0; i < _currentAirplane.Count; i++)
            {
                for (int j = i + 1; j < _currentAirplane.Count; j++)
                {
                    Airplane plane1 = _currentAirplane[i];
                    Airplane plane2 = _currentAirplane[j];
                    var track1 = plane1._tracks.First();
                    var track2 = plane2._tracks.First(); 

                    var time = DateTime.Compare(track1._Time, track2._Time) < 0 ? track1._Time : track2._Time;
                }

            }
        }

        public bool CheckForCollission(Tracks airplane1, Tracks airplane2)
        {
            double yPow = (Math.Pow(Math.Abs(airplane1._yCoordiante - airplane2._yCoordiante), 2));
            double xPow = (Math.Pow(Math.Abs(airplane1._xCoordiante - airplane2._xCoordiante), 2));
            double distance = Math.Sqrt(xPow + yPow);

            double altitude = (Math.Abs(airplane1._Altitude - airplane2._Altitude));

            if (altitude < _minVertical && distance < _minHorizontal) 
                return true;
            
            return false;
        }
    }
}