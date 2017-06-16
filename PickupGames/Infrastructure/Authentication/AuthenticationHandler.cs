using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using PickupGames.Infrastructure.Logging;

namespace PickupGames.Infrastructure.Authentication
{
    public  class AuthenticationHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            if (request.RequestUri.AbsolutePath.StartsWith("/swagger"))
            {
                return await base.SendAsync(request, cancellationToken);
            }

            IEnumerable<string> identityList;

            if (!request.Headers.TryGetValues("x-perfectserve-identity", out identityList))
            {
                var requestInfo = string.Format("{0} {1}", request.Method, request.RequestUri);
                await Task.Run(() =>
                    LoggingFactory.GetLogger().Log(string.Format("Request: {0}", requestInfo), LogType.Info));

                var errorMessagError = new HttpError("Missing x-perfectserve-identity header") { { "Code", (int)HttpStatusCode.BadRequest } };
                var errorResponse = request.CreateErrorResponse(HttpStatusCode.InternalServerError, errorMessagError);
                await Task.Run(() =>
                LoggingFactory.GetLogger().Log(string.Format("Response: {0}", errorResponse), LogType.Info));
                
                return await Task.Run(() => errorResponse);
            }

            var userId = identityList.ToList()[0];
            var principle = new GenericPrincipal(new GenericIdentity(userId, "UserId"), null);
            Thread.CurrentPrincipal = principle;
            HttpContext.Current.User = principle;

            var response = await base.SendAsync(request, cancellationToken);

            return response;
        }
    }
}