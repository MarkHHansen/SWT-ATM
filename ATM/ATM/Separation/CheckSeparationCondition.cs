using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using AirTrafficMonitor.AirplaneValidation;
using AirTrafficMonitor.Converter;
using AirTrafficMonitor.Logger;

namespace AirTrafficMonitor.Separation
{
    public class CheckSeparationCondition : ICheckSeparationCondition
    {
        LogFile _logfile = new LogFile();
        private int _minVertical = 300;
        private int _minHorizontal = 5000;
        public event EventHandler<PlaneConditionCheckedEventArgs> PlaneConditionChecked;
        public List<Airplane> _currentAirplane { get; set; }
        public List<SeparationCondition> Conditions;

        public CheckSeparationCondition(IAirplaneValidation plane)
        {
            plane.ValidationEvent += HandleAirplaneValidationEvent;
            Conditions = new List<SeparationCondition>();
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

                    var time = DateTime.Compare(plane1._Time, plane2._Time) < 0 ? plane1._Time : plane2._Time;

                    // Make a temporary SeparationCondition
                    Tuple<Airplane, Airplane> newPair = new Tuple<Airplane, Airplane>(plane1, plane2);
                    SeparationCondition newCond = new SeparationCondition(time, newPair);

                    // Hvis de er på koalitonskurs tilføj eller ikke tilføj 
                    if (CheckForCollission(plane1, plane2) == true)
                    {
                        bool isFound = false;
                        for (int k = 0; k < Conditions.Count; k++)
                        {
                            if (newCond.Equals(Conditions[k]))
                            {
                                isFound = true;
                            }
                        }
                        //Lav log hvis registreringen sker første gang
                        if (isFound == false)
                        {
                            _logfile.Print(new List<string>());
                            Conditions.Add(newCond);
                        }
                    }
                    // If not colliding check if it was before and then remove it from list
                    else
                    {
                        for (int k = 0; k < Conditions.Count; k++)
                        {
                            if (newCond.Equals(Conditions[k]))
                            {
                                Conditions.Remove(Conditions[k]);
                            }
                        }
                    }
                }
            }
        }

        public bool CheckForCollission(Airplane airplane1, Airplane airplane2)
        {
            double yPow = (Math.Pow(Math.Abs(airplane1._yCoordiante - airplane2._yCoordiante), 2));
            double xPow = (Math.Pow(Math.Abs(airplane1._xCoordiante - airplane2._xCoordiante), 2));

            double distance = Math.Sqrt(xPow + yPow);
            double altitude = (Math.Abs(airplane1._Altitude - airplane2._Altitude));

            if (altitude < _minVertical && distance < _minHorizontal)
            {
                return true;
            }
            return false;
        }
    }
}