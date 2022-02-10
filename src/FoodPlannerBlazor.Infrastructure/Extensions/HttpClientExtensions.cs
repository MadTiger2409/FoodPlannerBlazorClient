using FoodPlannerBlazor.Domain.Entities.Error.Incoming;
using FoodPlannerBlazor.Infrastructure.Common;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Infrastructure.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<ApiResponse<TResponse>> GetWithDeserializationAsync<TResponse>(this HttpClient client, string uri = "")
        {
            var response = await client.GetAsync(uri);
            var responseAsString = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseAsString))
                return new ApiResponse<TResponse> { Success = false, Error = new RequestError(response.StatusCode.ToString(), new()) };

            return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseAsString);
        }

        public static async Task<ApiResponse<TResponse>> PostWithDeserializationAsync<TResponse>(this HttpClient client, object objectToSend, string uri = "")
        {
            var objectToSendJson = JsonConvert.SerializeObject(objectToSend);

            var response = await client.PostAsync(uri, new StringContent(objectToSendJson));
            var responseAsString = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseAsString))
                return new ApiResponse<TResponse> { Success = false, Error = new RequestError(response.StatusCode.ToString(), new()) };

            return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseAsString);
        }

        public static async Task<ApiResponse<TResponse>> PutWithDeserializationAsync<TResponse>(this HttpClient client, object objectToSend, string uri = "")
        {
            var objectToSendJson = JsonConvert.SerializeObject(objectToSend);

            var response = await client.PutAsync(uri, new StringContent(objectToSendJson));
            var responseAsString = await response.Content.ReadAsStringAsync();

            if (string.IsNullOrWhiteSpace(responseAsString))
                return new ApiResponse<TResponse> { Success = false, Error = new RequestError(response.StatusCode.ToString(), new()) };

            return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseAsString);
        }
    }
}