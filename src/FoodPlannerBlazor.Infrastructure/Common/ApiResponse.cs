using FoodPlannerBlazor.Domain.Entities.Error.Incoming;

namespace FoodPlannerBlazor.Infrastructure.Common
{
    public class ApiResponse<T>
    {
        public bool Success { get; set; }
        public T Value { get; set; }
        public RequestError Error { get; set; }
    }
}