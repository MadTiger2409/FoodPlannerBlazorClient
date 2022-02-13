using FoodPlannerBlazor.Domain.Entities.Meal;

namespace FoodPlannerBlazor.Domain.Entities.Ingredient
{
    public record Ingredient(int Id, float Amount, int UnitId, int ProductId, MealShort Meal);
}