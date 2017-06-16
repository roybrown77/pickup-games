namespace PickupGames.Infrastructure.ServiceAccessor
{
    public interface IServiceAccessor
    {
        string ExecutePostCall(string uri, string method, object request);
        string ExecuteGetCall(string uri);
    }
}
