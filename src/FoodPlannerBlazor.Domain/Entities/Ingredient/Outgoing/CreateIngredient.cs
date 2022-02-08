namespace FoodPlannerBlazor.Domain.Entities.Ingredient.Outgoing
{
    public record CreateIngredient(int ProductId, int UnitId, float Amount);
}