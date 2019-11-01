using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATM.Logger;
using NUnit.Framework;

namespace ATM.Unit.Test
{
    [TestFixture]
    public class LogfileUnitTest
    {
        #region Arrange
        private LogFile __uut; 
        #endregion

        #region Act 
        [SetUp]
        public void Setup()
        {
            __uut = new LogFile();
        }
        #endregion

        #region Assert
        [Test]
        public void Test_make_folder_false()
        {
            __uut.MakeFolder();
            if (Directory.Exists(@"..\Logs"))
            {
                Directory.Delete(@"..\Logs");
            }
            Assert.That(System.IO.Directory.Exists(@"..\Logs"), Is.False);
        }

        [Test]
        public void Test_make_file_false()
        {
            __uut.MakeFile();
            if (Directory.Exists(@"..\Logs\logs.txt"))
            {
                Directory.Delete(@"..\Logs\Logs.txt");
            }
            Assert.That(Directory.Exists(@"..\Logs\Logs.txt"), Is.False);
        }

        [Test]
        public void Test_make_folder_true()
        {
            __uut.MakeFolder();
            Assert.That(System.IO.Directory.Exists(@"..\Logs"), Is.True);
        }

        [Test]
        public void Test_make_file_true()
        {
            __uut.MakeFile();
            Assert.That(Directory.Exists(@"..\Logs\Logs.txt"), Is.True);
        }

        [TestCase("Collision between HJ300 and HJ300")]
        public void Test_log_Collission_print(string messages)
        {
            //__uut.LogCollision(messages);
        }
        #endregion
    }
}