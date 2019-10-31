using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ATM.ValidateAirplane;
using ATM.Converter;
using ATM.Logger;

namespace ATM.Separation
{
    public class CheckSeparationCondition : ICheckSeparationCondition
    {
        LogFile _logfile = new LogFile();
        private ConsoleLogger _consolelogger = new ConsoleLogger();
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
            DetectCollisions();
        }

        public void DetectCollisions()
        {
            if (_currentAirplane.Count > 1)
            {
                for (int i = 1; i < 2; i++)
                {
                    Airplane plane1 = _currentAirplane[i];
                    Airplane plane2 = _currentAirplane[i - 1];

                    var time = DateTime.Compare(plane1._Time, plane2._Time) < 0 ? plane1._Time : plane2._Time;

                    Tuple<Airplane, Airplane> newPair = new Tuple<Airplane, Airplane>(plane1, plane2);
                    SeparationCondition newCondition = new SeparationCondition(time, newPair);

                    // Hvis de er på koalitonskurs tilføj eller ikke tilføj 
                    if (CheckForCollision(plane1, plane2) == true)
                    {
                        bool newCollision = false;
                        for (int k = 1; k <= Conditions.Count; k++)
                        {
                            if (newCondition.Equals(Conditions[k]))
                            {
                                newCollision = true;
                            }
                        }

                        //Lav log hvis registreringen sker første gang
                        if (newCollision == false)
                        {
                            _logfile.LogCollision(new List<string>()
                            {
                                "Timestamp: " + newCondition.Time + "Between plane: " + newCondition.Pair.Item1._tag +
                                "and" + newCondition.Pair.Item2._tag
                            });

                            Conditions.Add(newCondition);
                        }

                        _consolelogger.PrintCollision();
                        Conditions.Remove(newCondition);
                    }

                    // Hvis ingen collission sker tjek om de er forsvundet og derefter fjern dem 
                    //for (int k = 0; k <= Conditions.Count; k++)
                    //{
                    //    if (!newCondition.Equals(Conditions[k]))
                    //    {
                    //        Conditions.Remove(Conditions[k]);
                    //    }
                    //}
                    //else
                    //{
                    //    for (int k = 0; k < Conditions.Count; k++)
                    //    {
                    //        if (newCondition.Equals(Conditions[k]))
                    //        {
                    //            Conditions.Remove(Conditions[k]);
                    //        }
                    //    }
                    //}
                }
            }
        }

        private double CheckAltitude(Airplane airplane1, Airplane airplane2)
        {
            double yPow = (Math.Pow(Math.Abs(airplane1._yCoordiante - airplane2._yCoordiante), 2));
            double xPow = (Math.Pow(Math.Abs(airplane1._xCoordiante - airplane2._xCoordiante), 2));
            double distance = Math.Sqrt(xPow + yPow);
            return distance;
        }

        private double CheckDistance(Airplane airplane1, Airplane airplane2)
        {
            double difference = (Math.Abs(airplane1._Altitude - airplane2._Altitude));
            if (difference < 0)
            {
                difference = difference * (-1);
            }

            return difference;
        }
        public bool CheckForCollision(Airplane airplane1, Airplane airplane2)
        {
            if (CheckAltitude(airplane1, airplane2) < _minVertical && CheckDistance(airplane1, airplane2) < _minHorizontal)
            {
                return true;
            }
            return false;
        }
    }
}