using FoodPlannerBlazor.Domain.Entities.Common;

namespace FoodPlannerBlazor.Domain.Entities.PlannedMeal
{
    public class PlannedMealForGrouping : BaseEntity
    {
        public int OrdinalNumber { get; set; }
        public Meal.Meal Meal { get; set; }
    }
}