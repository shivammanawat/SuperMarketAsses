using NUnit.Framework;
using SuperMarket.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SuperMarket_Test.LoggerTest
{
    [TestFixture]
    public class LoggerTest
    {
        private ILogger _logger;

        [SetUp]
        public void Setup()
        {
            _logger = new Logger();
        }

        [TearDown]
        public void TearDown()
        {
            _logger = null;
        }

        [Test]
        public void ShouldWriteToConsole()
        {
            var result = new StringWriter();
            string message = "Print out to console ";
            Console.SetOut(result);
            _logger.write(message);
            Assert.That(result.ToString(), Is.EqualTo(message + string.Format(Environment.NewLine)));
        }
    }
}
