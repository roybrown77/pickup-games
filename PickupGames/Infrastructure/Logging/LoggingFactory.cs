namespace PickupGames.Infrastructure.Logging
{
    public class LoggingFactory
    {
        public static IApplicationLogger GetLogger()
        {
            return new MockApplicationLogger();
        }
    }
}
