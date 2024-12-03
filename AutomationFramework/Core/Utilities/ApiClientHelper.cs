using Newtonsoft.Json;
using RestSharp;
using System;

namespace AutomationFramework.Core.Utilities
{
    /// <summary>
    /// Provides helper methods for working with API requests and responses.
    /// </summary>
    public static class ApiClientHelper
    {
        /// <summary>
        /// Serializes an object to JSON format.
        /// </summary>
        public static string SerializeToJson(object payload)
        {
            return JsonConvert.SerializeObject(payload);
        }

        /// <summary>
        /// Deserializes a JSON response to a specified type.
        /// </summary>
        public static T DeserializeFromJson<T>(IRestResponse response)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(response.Content);
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Failed to deserialize JSON response.");
                throw;
            }
        }
    }
}