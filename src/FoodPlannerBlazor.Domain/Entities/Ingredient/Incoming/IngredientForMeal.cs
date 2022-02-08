namespace FoodPlannerBlazor.Domain.Entities.Ingredient.Incoming
{
    public record IngredientForMeal(int Id, float Amount, Product.Incoming.Product Product, Unit.Incoming.Unit Unit);
}