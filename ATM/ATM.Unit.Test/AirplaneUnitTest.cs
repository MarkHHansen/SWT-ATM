using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ATM.Converter;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class AirplaneUnitTest
    {
        private Airplane plane;
        [SetUp]
        public void SetUp()
        {
            plane = new Airplane();
        }

        [Test]
        public void setTag_Correct()
        {
            plane._tag = "AAXX01";

            Assert.That(plane._tag, Is.EqualTo("AAXX01"));
        }

        [Test]
        public void getTag_Correct()
        {
            plane._tag = "AAXX01";
            string temp = plane._tag;

            Assert.That(plane._tag, Is.EqualTo(temp));
        }

        [Test]
        public void setSeperation_Correct()
        {
            plane._seperationCodition = true;

            Assert.That(plane._seperationCodition, Is.EqualTo(true));
        }

        [Test]
        public void getSeperation_Correct()
        {
            plane._seperationCodition = true;
            bool temp = plane._seperationCodition;

            Assert.That(temp, Is.EqualTo(true));
        }

        [Test]
        public void getTime_Correct()
        {
            DateTime dt = new DateTime(1974, 10, 9, 8, 5, 3);
            plane._Time = dt;
            DateTime temp = plane._Time;

            Assert.That(temp, Is.EqualTo(dt));
        }

        [Test]
        public void getCompasCourse_Correct()
        {
            plane._compasCourse = 160.0;
            double temp = plane._compasCourse;

            Assert.That(temp, Is.EqualTo(160.0));
        }

        [Test]
        public void getVelocity_Correct()
        {
            plane._velocity = 7000;
            double temp = plane._velocity;

            Assert.That(temp, Is.EqualTo(7000));
        }
    }
}
