using System.Threading;

namespace PickupGames.Infrastructure.Logging
{
    public class InternalLog4NetAdapter : IApplicationLogger
    {
        //private readonly ILogger _log;

        public InternalLog4NetAdapter()
        {            
        }

        public void Log(string message, LogType logType)
        {
            var secureMessage = new LogMessage(message).GetSecureMessage();

            var fullMessage = "User Name: " + Thread.CurrentPrincipal.Identity.Name + ", Thread Id: " + Thread.CurrentThread.ManagedThreadId + ", " + secureMessage;

            switch (logType)
            {
                case LogType.Info:
                    _log.Info(fullMessage);
                    break;
                case LogType.Error:
                    _log.Error(fullMessage);
                    break;
                case LogType.Warning:
                    _log.Warn(fullMessage);
                    break;
                default:
                    _log.Error(fullMessage);
                    break;
            }
        }        
    }
}