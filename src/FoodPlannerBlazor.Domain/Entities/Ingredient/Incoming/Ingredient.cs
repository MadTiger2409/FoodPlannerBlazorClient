using FoodPlannerBlazor.Domain.Entities.Meal.Incoming;

namespace FoodPlannerBlazor.Domain.Entities.Ingredient.Incoming
{
    public record Ingredient(int Id, float Amount, int UnitId, int ProductId, MealShort Meal);
}