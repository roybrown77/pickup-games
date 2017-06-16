using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using PickupGames.Infrastructure.Exceptions;
using PickupGames.Infrastructure.Logging;

namespace PickupGames.Infrastructure.ServiceAccessor
{
    public class HttpClientServiceAccessor : IServiceAccessor
    {
        private readonly IApplicationLogger _logger;

        public HttpClientServiceAccessor(IApplicationLogger logger)
        {
            _logger = logger;
        }

        public string ExecutePostCall(string uri, string method, object request)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    
                    var correlationId = Guid.NewGuid().ToString();
                    var requestString = JsonConvert.SerializeObject(request);

                    _logger.Log(string.Format("Correlation Id: {0} - HttpClientServiceAccessor Request: {1}", correlationId, requestString), LogType.Info);
                    var response = client.PostAsJsonAsync(method, request).Result;
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    _logger.Log(string.Format("Correlation Id: {0} - HttpClientServiceAccessor Response: {1}", correlationId, responseData), LogType.Info);
                    return responseData;
                }            
            }
            catch (ArgumentNullException ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Connection string not present: " + ex.Message);                
            }
            catch (UriFormatException ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Invalid connection format: " + ex.Message);                
            }
            catch (AggregateException ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Invalid connection: " + ex.Message);                
            }            
        }

        public string ExecuteGetCall(string uri)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(uri);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));                    

                    var correlationId = Guid.NewGuid().ToString();

                    _logger.Log(string.Format("Correlation Id: {0} - Request: {1}", correlationId, uri), LogType.Info);
                    var response = client.GetAsync(uri).Result;
                    var responseData = response.Content.ReadAsStringAsync().Result;
                    _logger.Log(string.Format("Correlation Id: {0} - Response: {1}", correlationId, responseData), LogType.Info);
                    return responseData;
                }
            }
            catch (ArgumentNullException ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Connection string not present: " + ex.Message);
            }
            catch (UriFormatException ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Invalid connection format: " + ex.Message);
            }
            catch (AggregateException ex)
            {
                throw new ApplicationLayerException(HttpStatusCode.InternalServerError, "Invalid connection: " + ex.Message);
            }      
        }
    }   
}
