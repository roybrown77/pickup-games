namespace PickupGames.Infrastructure.Logging
{
    public class LoggingFactory
    {
        private static IApplicationLogger _logger;

        public static void InitializeLogFactory(IApplicationLogger logger)
        {
            _logger = logger;
        }

        public static IApplicationLogger GetLogger()
        {
            return _logger;
        }
    }
}
