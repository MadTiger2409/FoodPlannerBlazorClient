using FoodPlannerBlazor.Domain.Entities.Common;

namespace FoodPlannerBlazor.Domain.Entities.Ingredient
{
    public class IngredientForMeal : BaseEntity
    {
        public float Amount { get; set; }
        public Product.Product Product { get; set; } = new();
        public Unit.Unit Unit { get; set; } = new();
    }
}