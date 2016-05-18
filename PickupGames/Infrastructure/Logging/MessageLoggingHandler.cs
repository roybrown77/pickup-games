using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace PickupGames.Infrastructure.Logging
{
    //for more info, read http://weblogs.asp.net/fredriknormen/log-message-request-and-response-in-asp-net-webapi

    public class MessageLoggingHandler : MessageHandler
    {
        protected override async Task IncommingMessageAsync(string correlationId, string requestInfo, byte[] message)
        {
            await Task.Run(() =>
                LoggingFactory.GetLogger().Log(string.Format("Correlation Id: {0} - Request: {1}\r\n{2}", correlationId, requestInfo, System.Text.Encoding.UTF8.GetString(message)), LogType.Info));
        }


        protected override async Task OutgoingMessageAsync(string correlationId, string requestInfo, byte[] message)
        {
            await Task.Run(() =>
                LoggingFactory.GetLogger().Log(string.Format("Correlation Id: {0} - Response: {1}\r\n{2}", correlationId, requestInfo, System.Text.Encoding.UTF8.GetString(message)), LogType.Info));
        }
    }

    public abstract class MessageHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //if (!request.Headers.TryGetValues("correlation-id", out correlationList))
            //{
            //    HttpContext.Current.Items["CorrelationId"] = Guid.NewGuid().ToString();
            //}
            //else
            //{
            //    HttpContext.Current.Items["CorrelationId"] = correlationList.ToList()[0];
            //}

            //var correlationId = (string)HttpContext.Current.Items["CorrelationId"];

            var corrId = Guid.NewGuid().ToString();
            var requestInfo = string.Format("{0} {1}", request.Method, request.RequestUri);

            var requestMessageBytes = await request.Content.ReadAsByteArrayAsync();
            await IncommingMessageAsync(corrId, requestInfo, requestMessageBytes);

            var response = await base.SendAsync(request, cancellationToken);

            byte[] responseMessageBytes;
            if (response.IsSuccessStatusCode)
                responseMessageBytes = response.Content == null ? System.Text.Encoding.UTF8.GetBytes(response.ReasonPhrase) : await response.Content.ReadAsByteArrayAsync();
            else
                responseMessageBytes = System.Text.Encoding.UTF8.GetBytes(response.ReasonPhrase);

            await OutgoingMessageAsync(corrId, requestInfo, responseMessageBytes);

            return response;
        }

        protected abstract Task IncommingMessageAsync(string correlationId, string requestInfo, byte[] message);
        protected abstract Task OutgoingMessageAsync(string correlationId, string requestInfo, byte[] message);
    }
}