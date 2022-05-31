using FoodPlannerBlazor.Domain.Entities.Common;
using FoodPlannerBlazor.Domain.Entities.Ingredient.Outgoing;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Domain.Entities.Meal.Outgoing
{
    public class CreateMeal : NamedOnlyEntity
    {
        public List<CreateIngredient> Ingredients { get; set; } = new();
    }
}