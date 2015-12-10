namespace PickupGames.Infrastructure.Response
{
    public abstract class ResponseBase
    {
        private ResponseStatus _status = ResponseStatus.Success;

        public ResponseStatus Status
        {
            get { return _status; }
            set { _status = value; }

        }
        public string Message { get; set; }
    }
}