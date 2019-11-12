using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Converter;
using ATM.Logger;
using ATM.ValidateAirplane;
using NSubstitute;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class LogfileUnitTest
    {
        #region Arrange
        private LogFile _Loguut;
        private IConLogger _Conuut;

        #endregion

        #region Act 
        [SetUp]
        public void Setup()
        {
            _Conuut = Substitute.For<IConLogger>();
            _Loguut = new LogFile();
        }
        #endregion

        #region AssertLogFile
        [Test]
        public void Test_make_folder_false()
        {
            _Loguut.MakeFolder();
            if (Directory.Exists(@"..\Logs"))
            {
                Directory.Delete(@"..\Logs");
            }
            Assert.That(System.IO.Directory.Exists(@"..\Logs"), Is.False);
        }
        /*
        [Test]
        public void Test_make_file_false()
        {
            __uut.MakeFile();
            if (Directory.Exists(@"..\Logs\logs.txt"))
            {
                Directory.Delete(@"..\Logs\Logs.txt");
            }
            Assert.That(Directory.Exists(@"..\Logs\Logs.txt"), Is.Null);
        }*/

        [Test]
        public void Test_make_folder_true()
        {
            _Loguut.MakeFolder();
            Assert.That(System.IO.Directory.Exists(@"..\Logs"), Is.True);
        }


        [Test]
        public void Test_log_Collission_print()
        {
            List<string> temp = new List<string>();
            temp.Add("Collision between HJ300 and HJ300");
            _Loguut.LogCollision(temp);
        }

        [Test]
        public void TestVarCollision_Get()
        {
            List<string> temp = new List<string>();
            temp.Add("AAXX01 og AAXX02");

            _Loguut.Collision = temp;

            Assert.That(_Loguut.Collision, Is.EqualTo(temp));
        }
        #endregion

        #region AssertConsoleLogger

        [Test]
        public void ConsoleLogger_PrintPlanes_TwoPlanes()
        {
            List<Airplane> temp = new List<Airplane>();
            Airplane ap1 = new Airplane();
            ap1._tag = "AAXX01";
            ap1._xCoordiante = 30000;
            ap1._yCoordiante = 30000;
            ap1._Altitude = 1800;
            ap1._Time = DateTime.Today;
            ap1._compasCourse = 60.0;
            ap1._seperationCodition = false;
            ap1._velocity = 8000.0;
            Airplane ap2 = new Airplane();
            ap2._tag = "AAXX02";
            ap2._xCoordiante = 35000;
            ap2._yCoordiante = 35000;
            ap2._Altitude = 1700;
            ap2._Time = DateTime.Today;
            ap2._compasCourse = 60.0;
            ap2._seperationCodition = false;
            ap2._velocity = 8000.0;
            temp.Add(ap1);
            temp.Add(ap2);

            _Conuut.PrintAirplanes(temp);

            _Conuut.Received(1).PrintAirplanes(temp);
        }

        #endregion
    }
}
