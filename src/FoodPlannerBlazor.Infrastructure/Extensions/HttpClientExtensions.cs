using FoodPlannerBlazor.Domain.Entities.Error;
using FoodPlannerBlazor.Infrastructure.Common;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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
                        Error = new RequestError
                        {
                            Title = response.StatusCode.ToString(),
                            Details = new() { "Something went wrong. Try again later." }
                        }
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseAsString);
            }
            catch (Exception)
            {
                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Error = new RequestError
                    {
                        Title = "Unknown error",
                        Details = new() { "Something went wrong. Try again later." }
                    }
                };
            }
        }

        public static async Task<ApiResponse<TResponse>> PostWithDeserializationAsync<TResponse>(this HttpClient client, object objectToSend, string uri = "")
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(objectToSend), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(uri, httpContent);
                var responseAsString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseAsString))
                {
                    return new ApiResponse<TResponse>
                    {
                        Success = false,
                        Error = new RequestError
                        {
                            Title = response.StatusCode.ToString(),
                            Details = new() { "Something went wrong. Try again later." }
                        }
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseAsString);
            }
            catch (Exception)
            {
                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Error = new RequestError
                    {
                        Title = "Unknown error",
                        Details = new() { "Something went wrong. Try again later." }
                    }
                };
            }
        }

        public static async Task<ApiResponse<TResponse>> PutWithDeserializationAsync<TResponse>(this HttpClient client, object objectToSend, string uri = "")
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(objectToSend), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PutAsync(uri, httpContent);
                var responseAsString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(responseAsString))
                {
                    return new ApiResponse<TResponse>
                    {
                        Success = false,
                        Error = new RequestError
                        {
                            Title = response.StatusCode.ToString(),
                            Details = new() { "Something went wrong. Try again later." }
                        }
                    };
                }

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(responseAsString);
            }
            catch (Exception)
            {
                return new ApiResponse<TResponse>
                {
                    Success = false,
                    Error = new RequestError
                    {
                        Title = "Unknown error",
                        Details = new() { "Something went wrong. Try again later." }
                    }
                };
            }
        }
    }
}