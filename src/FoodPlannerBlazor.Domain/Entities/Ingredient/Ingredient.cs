using FoodPlannerBlazor.Domain.Entities.Common;
using FoodPlannerBlazor.Domain.Entities.Meal;

namespace FoodPlannerBlazor.Domain.Entities.Ingredient
{
    public class Ingredient : BaseEntity
    {
        public float Amount { get; set; }

        public int UnitId { get; set; }
        public int ProductId { get; set; }
        public MealShort Meal { get; set; }
    }
}