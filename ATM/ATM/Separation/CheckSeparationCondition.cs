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
        //public event EventHandler<PlaneConditionCheckedEventArgs> PlaneConditionChecked;
        //public List<Airplane> _currentAirplane { get; set; }
        public List<SeparationCondition> Conditions;

        public CheckSeparationCondition(IAirplaneValidation plane)
        {
            plane.ValidationEvent += HandleAirplaneValidationEvent;
            Conditions = new List<SeparationCondition>();
        }

        private void HandleAirplaneValidationEvent(object sender, ValidationEventArgs e)
        {
            List<Airplane> currentAirplane = e.PlanesToValidate;
            DetectCollisions(currentAirplane);
        }

        public void DetectCollisions(List<Airplane> valAirplanes)
        {
            foreach (var plane1 in valAirplanes)
            {
                foreach (var plane2 in valAirplanes)
                {
                    var time = DateTime.Compare(plane1._Time, plane2._Time) < 0 ? plane1._Time : plane2._Time;
                    Tuple<Airplane, Airplane> newPair = new Tuple<Airplane, Airplane>(plane1, plane2);
                    SeparationCondition newCondition = new SeparationCondition(time, newPair);
                    if (plane1._tag != plane2._tag)
                    {
                        if (CheckForCollision(plane1, plane2))
                        {
                            _logfile.LogCollision(new List<string>()
                            {
                                "Timestamp: " + newCondition.Time + "  Between plane: " + newCondition.Pair.Item1._tag +
                                "and" + newCondition.Pair.Item2._tag
                            });

                            Conditions.Add(newCondition);
                        }
                    }

                    if (!newCondition.Equals(Conditions))
                    {
                        Conditions.Remove(newCondition);
                    }
                }
            }
        }

        public List<SeparationCondition> GetCondition()
        {
            return Conditions;
        }

        public  int CheckDistance(Airplane airplane1, Airplane airplane2)
        {
            double yPow = (Math.Pow(Math.Abs(airplane1._yCoordiante - airplane2._yCoordiante), 2));
            double xPow = (Math.Pow(Math.Abs(airplane1._xCoordiante - airplane2._xCoordiante), 2));
            double distance = Math.Sqrt(xPow + yPow);
            return Convert.ToInt32(distance); ;
        }

        public  int CheckAltitude(Airplane airplane1, Airplane airplane2)
        {
            double difference = (Math.Abs(airplane1._Altitude - airplane2._Altitude));

            return Convert.ToInt32(difference);
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