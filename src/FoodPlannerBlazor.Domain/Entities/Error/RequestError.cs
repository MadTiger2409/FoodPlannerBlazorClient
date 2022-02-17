using System.Collections.Generic;

namespace FoodPlannerBlazor.Domain.Entities.Error
{
    public class RequestError
    {
        public string Title { get; set; }
        public List<string> Details { get; set; } = new();
    }
}