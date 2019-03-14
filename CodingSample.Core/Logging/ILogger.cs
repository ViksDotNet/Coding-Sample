using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSample.Core.Logging
{
    public interface ILogger
    {
        void Debug(string message);

        void Error(string message);
        void Error(Exception ex);

        void Fatal(string message);
        void Fatal(Exception ex);
    }
}
