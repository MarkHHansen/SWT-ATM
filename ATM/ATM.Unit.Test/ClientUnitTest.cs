using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ATM.Converter;
using ATM.Logger;
using ATM.Separation;
using ATM.ValidateAirplane;
using ATM.OutputValidation_;
using ATM;

namespace ATM.Unit.Test
{
    [TestFixture()]
    public class ClientUnitTest
    {
        private IConvertFilter _convertFilter;
        private IAirplaneValidation _airplaneValidation;
        private ICheckSeparationCondition _checkSeparationCondition;
        private OutputFilter _outputFilter;
        private Client _uut;
        private Program main;
        

        [SetUp]
        public void Setup()
        {
            _uut = new Client();
            main = new Program();
        }

        [Test]
        public void Construtor_Test()
        {
            // Assert
            Assert.NotNull(_uut);
        }

        [Test]
        public void MainClassTest()
        {
            Assert.NotNull(main);
        }
        [Test]
        public void MainExTest()
        {

        }
    }
}
