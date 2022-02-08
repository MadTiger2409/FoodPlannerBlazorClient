using FoodPlannerBlazor.Domain.Entities.Ingredient.Incoming;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Domain.Entities.Meal.Incoming
{
    public record Meal(int Id, string Name, List<IngredientForMeal> Ingredients);
}