using FoodPlannerBlazor.Domain.Entities.Common;
using FoodPlannerBlazor.Domain.Entities.Error;
using FoodPlannerBlazor.Infrastructure.Common;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
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
                var contentAsString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(contentAsString))
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

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(contentAsString);
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

        public static async Task<ApiResponse<FileDataEntity>> GetFileWithDeserializationAsync(this HttpClient client, string uri = "")
        {
            try
            {
                var response = await client.GetAsync(uri);

                if (!response.IsSuccessStatusCode)
                {
                    var contentAsString = await response.Content.ReadAsStringAsync();
                    if (string.IsNullOrWhiteSpace(contentAsString))
                        return GetFailedApiResponse<FileDataEntity>(response.StatusCode.ToString());

                    return JsonConvert.DeserializeObject<ApiResponse<FileDataEntity>>(contentAsString);
                }

                var contentAsByteArray = await response.Content.ReadAsByteArrayAsync();
                var fileName = response.Content.Headers.ContentDisposition.FileName;

                return new ApiResponse<FileDataEntity>
                {
                    Success = true,
                    Error = null,
                    Value = new()
                    {
                        Content = contentAsByteArray,
                        NameWithExtension = fileName
                    }
                };
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetFailedApiResponse<FileDataEntity>();
            }
        }

        public static async Task<ApiResponse<TResponse>> PostWithDeserializationAsync<TResponse>(this HttpClient client, object objectToSend, string uri = "")
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(objectToSend), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PostAsync(uri, httpContent);
                var contentAsString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(contentAsString))
                    return GetFailedApiResponse<TResponse>(response.StatusCode.ToString());

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(contentAsString);
            }
            catch (Exception)
            {
                return GetFailedApiResponse<TResponse>();
            }
        }

        public static async Task<ApiResponse<TResponse>> PutWithDeserializationAsync<TResponse>(this HttpClient client, object objectToSend, string uri = "")
        {
            try
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(objectToSend), Encoding.UTF8);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                var response = await client.PutAsync(uri, httpContent);
                var contentAsString = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrWhiteSpace(contentAsString))
                    return GetFailedApiResponse<TResponse>(response.StatusCode.ToString());

                return JsonConvert.DeserializeObject<ApiResponse<TResponse>>(contentAsString);
            }
            catch (Exception)
            {
                return GetFailedApiResponse<TResponse>();
            }
        }

        public static async Task<ApiResponse<string>> DeleteWithDeserializationAsync(this HttpClient client, int id)
        {
            try
            {
                var response = await client.DeleteAsync(id.ToString());

                var contentAsString = await response.Content.ReadAsStringAsync();

                if (response.StatusCode == HttpStatusCode.NoContent)
                    return new ApiResponse<string>
                    {
                        Success = true,
                        Value = "The content has been successfully deleted."
                    };

                if (string.IsNullOrWhiteSpace(contentAsString))
                    return GetFailedApiResponse<string>(response.StatusCode.ToString());

                return JsonConvert.DeserializeObject<ApiResponse<string>>(contentAsString);
            }
            catch (Exception)
            {
                return GetFailedApiResponse<string>();
            }
        }

        private static ApiResponse<TModel> GetFailedApiResponse<TModel>(string title = "Unknown error")
        {
            return new ApiResponse<TModel>
            {
                Success = false,
                Error = new RequestError
                {
                    Title = title,
                    Details = new() { "Something went wrong. Try again later." }
                }
            };
        }
    }
}