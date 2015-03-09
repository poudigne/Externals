using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;

namespace Network.PSoft.Logging
{
  public class LoggingService
  {
    private LoggingService instance;
    private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    public LoggingService()
    {
       log4net.Config.XmlConfigurator.Configure();
    }

    public LoggingService GetInstance()
    {
      if (instance == null)
        instance = new LoggingService();

      return instance;
    }

    public static void LogDebug(string message)
    {
      log.Debug(message);
    }

  }
}
