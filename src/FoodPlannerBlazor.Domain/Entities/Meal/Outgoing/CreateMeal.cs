using FoodPlannerBlazor.Domain.Entities.Ingredient.Outgoing;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Domain.Entities.Meal.Outgoing
{
    public record CreateMeal(string Name, List<CreateIngredient> Ingredients);
}