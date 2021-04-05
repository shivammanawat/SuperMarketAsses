using System;
using System.Collections.Generic;
using System.Text;

namespace SuperMarket.Logging
{
   public interface ILogger
    {
        void write(string msg);
    }
}
