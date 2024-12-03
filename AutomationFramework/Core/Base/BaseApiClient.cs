using RestSharp;
using Serilog;
using System;

namespace AutomationFramework.Core.Base
{
    /// <summary>
    /// Represents a base class for API clients, providing methods for executing HTTP requests.
    /// </summary>
    public class BaseApiClient
    {
        protected RestClient Client;

        /// <summary>
        /// Initializes a new instance of the BaseApiClient class.
        /// </summary>
        public BaseApiClient(string baseUrl)
        {
            Client = new RestClient(baseUrl);
            Logger.Initialize();
            Log.Information("API Client initialized with base URL: {BaseUrl}", baseUrl);
        }

        /// <summary>
        /// Executes an API request and returns the response.
        /// </summary>
        public RestResponse ExecuteRequest(RestRequest request)
        {
            try
            {
                Log.Information("Executing API request: {Method} {Resource}", request.Method, request.Resource);
                var response = Client.Execute(request);
                Log.Information("Response received: {StatusCode}", response.StatusCode);
                return response;
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error occurred while executing API request.");
                throw;
            }
        }
    }
}