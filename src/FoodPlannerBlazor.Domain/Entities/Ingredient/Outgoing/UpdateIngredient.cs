namespace FoodPlannerBlazor.Domain.Entities.Ingredient.Outgoing
{
    public record UpdateIngredient(int ProductId, int UnitId, float Amount);
}