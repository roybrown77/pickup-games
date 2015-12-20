using System.Text.RegularExpressions;

namespace PickupGames.Infrastructure.Logging
{
    public class LogMessage
    {
        private readonly string _message;

        public LogMessage(string message)
        {
            _message = message;
        }

        public string GetSecureMessage()
        {
            var secureMessage = Regex.Replace(_message, "(?<=password=)([^&]*)", "xxxxxxx");
            secureMessage = Regex.Replace(secureMessage, "(?<=\"Password\":)([^(,|})]*)", "\"xxxxxxx\"");
            secureMessage = Regex.Replace(secureMessage, "(?<=\'Password\':)([^(,|})]*)", "\'xxxxxxx\'");
            return secureMessage;
        }
    }
}
