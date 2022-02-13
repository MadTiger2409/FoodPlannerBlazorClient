using FoodPlannerBlazor.Domain.Entities.Ingredient;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Domain.Entities.Meal
{
    public record Meal(int Id, string Name, List<IngredientForMeal> Ingredients);
}