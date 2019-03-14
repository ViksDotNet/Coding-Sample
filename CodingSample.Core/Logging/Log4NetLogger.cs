using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingSample.Core.Logging
{
    public class Log4NetLogger : ILogger
    {
        private ILog _logger;
        public Log4NetLogger()
        {
            _logger = LogManager.GetLogger("ErrorLog");
        }

        public void Debug(string message)
        {
            _logger.Debug(message);
        }

        public void Error(string message)
        {
            _logger.Error(message);
        }
        public void Error(Exception ex)
        {
            _logger.Error(ex);

        }

        public void Fatal(string message)
        {
            _logger.Fatal(message);
        }
        public void Fatal(Exception ex)
        {
            _logger.Fatal(ex);
        }
    }
}
