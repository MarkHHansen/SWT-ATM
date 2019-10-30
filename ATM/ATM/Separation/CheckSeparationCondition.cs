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
        private void HandleAirplaneValidationEvent (object sender, ValidationEventArgs e)
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
        public int GetAltitudeDelta(Airplane t1, Airplane t2)
        {
            double delta = t1._Altitude - t2.Altitude;

            if (delta < 0)
                delta = delta * (-1);
            return Convert.ToInt32(delta);
        }

        public int GetDistance(Track t1, Track t2)
        {
            var deltaX = t1.PositionX - t2.PositionX;
            var deltaY = t1.PositionY - t2.PositionY;

            int result = Convert.ToInt32(Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2)));

            return result;
        }
        public void CheckForCollission(IAirplane airplane1, IAirplane airplane2)
        {

        }
    }
}