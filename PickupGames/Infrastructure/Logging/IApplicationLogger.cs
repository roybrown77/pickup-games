namespace PickupGames.Infrastructure.Logging
{
    public interface IApplicationLogger
    {
        void Log(string message, LogType logType);
    }
}
