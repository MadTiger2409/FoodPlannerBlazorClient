using FoodPlannerBlazor.Domain.Entities.Error;
using FoodPlannerBlazor.Infrastructure.Common;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Infrastructure.Extensions
{
    public static class HttpClientExtensions
    {
        public static async Task<ApiResponse<TResponse>> GetWithDeserializationAsync<TResponse>(this HttpClient client, string uri = "")
        {
            try
            {
                var response = await client.GetAsync(uri);
                var responseAsString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseAsString))
                {
                    return new ApiResponse<TResponse>
                    {
                        Success = false,
                        Error = new RequestError(response.StatusCode.ToString(), new() { "Something went wrong. Try again later." })
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseAsString);
            }
            catch (Exception)
            {
                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Error = new RequestError("Unknown error", new() { "Something went wrong. Try again later." })
                };
            }
        }

        public static async Task<ApiResponse<TResponse>> PostWithDeserializationAsync<TResponse>(this HttpClient client, object objectToSend, string uri = "")
        {
            try
            {
                var objectToSendJson = JsonConvert.SerializeObject(objectToSend);

                var response = await client.PostAsync(uri, new StringContent(objectToSendJson));
                var responseAsString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseAsString))
                {
                    return new ApiResponse<TResponse>
                    {
                        Success = false,
                        Error = new RequestError(response.StatusCode.ToString(), new() { "Something went wrong. Try again later." })
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseAsString);
            }
            catch (Exception)
            {
                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Error = new RequestError("Unknown error", new() { "Something went wrong. Try again later." })
                };
            }
        }

        public static async Task<ApiResponse<TResponse>> PutWithDeserializationAsync<TResponse>(this HttpClient client, object objectToSend, string uri = "")
        {
            try
            {
                var objectToSendJson = JsonConvert.SerializeObject(objectToSend);

                var response = await client.PutAsync(uri, new StringContent(objectToSendJson));
                var responseAsString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseAsString))
                    return new ApiResponse<TResponse> { Success = false, Error = new RequestError(response.StatusCode.ToString(), new()) };

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseAsString);
            }
            catch (Exception)
            {
                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Error = new RequestError("Unknown error", new() { "Something went wrong. Try again later." })
                };
            }
        }
    }
}