using FoodPlannerBlazor.Domain.Entities.Common;
using FoodPlannerBlazor.Domain.Entities.Ingredient;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Domain.Entities.Meal
{
    public class Meal : NamedEntity
    {
        public List<IngredientForMeal> Ingredients { get; set; } = new();
    }
}