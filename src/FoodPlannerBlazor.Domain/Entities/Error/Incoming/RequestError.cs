using System.Collections.Generic;

namespace FoodPlannerBlazor.Domain.Entities.Error.Incoming
{
    public record RequestError(string Title, List<string> Details);
}