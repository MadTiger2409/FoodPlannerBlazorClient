using System.Collections.Generic;

namespace FoodPlannerBlazor.Domain.Entities.Error
{
    public record RequestError(string Title, List<string> Details);
}