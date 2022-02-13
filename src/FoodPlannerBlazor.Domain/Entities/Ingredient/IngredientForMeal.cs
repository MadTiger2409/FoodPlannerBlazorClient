namespace FoodPlannerBlazor.Domain.Entities.Ingredient
{
    public record IngredientForMeal(int Id, float Amount, Product.Product Product, Unit.Unit Unit);
}