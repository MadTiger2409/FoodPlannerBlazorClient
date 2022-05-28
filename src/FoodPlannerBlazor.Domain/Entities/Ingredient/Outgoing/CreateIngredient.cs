namespace FoodPlannerBlazor.Domain.Entities.Ingredient.Outgoing
{
    public class CreateIngredient
    {
        public int ProductId { get; set; }
        public int UnitId { get; set; }
        public float Amount { get; set; }
    }
}