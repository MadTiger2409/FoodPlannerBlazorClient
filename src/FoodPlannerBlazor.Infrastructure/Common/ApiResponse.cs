using FoodPlannerBlazor.Domain.Entities.Error;

namespace FoodPlannerBlazor.Infrastructure.Common
{
    public class ApiResponse<TEntityBasedResponse>
    {
        public bool Success { get; set; }
        public TEntityBasedResponse Value { get; set; }
        public RequestError Error { get; set; }
    }
}