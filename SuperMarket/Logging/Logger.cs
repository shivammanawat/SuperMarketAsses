using System;
using System.Collections.Generic;
using System.Text;
using SuperMarket.Logging;

namespace SuperMarket.Logging
{
    public class Logger : ILogger
    {
        public void write(string msg)
        {
            Console.WriteLine(msg);
        }
    }
}
