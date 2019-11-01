using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;
using ATM.Separation;
using Castle.Core;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class SeparationConditionTest
    {
        #region Arrange
        private SeparationCondition uut;
        private Airplane TestPlane1;
        private Airplane TestPlane2;
        #endregion

        #region Act

        [SetUp]
        public void Setup()
        {
            TestPlane1 = Substitute.For<Airplane>();
            TestPlane2 = Substitute.For<Airplane>();
            Tuple<Airplane, Airplane> newPair = new Tuple<Airplane, Airplane>(TestPlane1, TestPlane2);
            uut = new SeparationCondition(new DateTime(01112019), newPair);
        }

        #endregion

        #region Assert

        [Test]
        public void Test_pair_equal_planes()
        {
            Assert.That((uut.Pair), Is.EqualTo(new Tuple<Airplane, Airplane>(TestPlane1, TestPlane2)));
        }

        [TestCase("planeEqual", "planeEqual", true, TestName = "Seperation Logged True")]
        public void Test_equal_function(string planetag1, string planetag2, bool result)
        {
            TestPlane1._tag = planetag1;
            TestPlane2._tag = planetag2;

            SeparationCondition testresult = new SeparationCondition(new DateTime(2019), 
                new Tuple<Airplane, Airplane>(TestPlane1, TestPlane2));

            //testCond.Pair.Item1 & Item2
            Assert.That((uut.Equals(testresult)), Is.EqualTo(result));
        }
        #endregion
    }
}

