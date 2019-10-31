using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;
using ATM.Separation;
using ATM.ValidateAirplane;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    class CheckSeparationConditionUnitTest
    {
        private Airplane TestPlane1;
        private Airplane TestPlane2;
        private List<Airplane> TestSeparationInAirspace;
        private IAirplaneValidation plane; 

        private CheckSeparationCondition uut; 
        [SetUp]
        public void Setup()
        {
            TestPlane1 = Substitute.For<Airplane>();
            TestPlane2 = Substitute.For<Airplane>();

            TestSeparationInAirspace = new List<Airplane>();

            TestSeparationInAirspace.Add(TestPlane1);
            TestSeparationInAirspace.Add(TestPlane2);
            uut = new CheckSeparationCondition(plane);
        }
    }
}
