namespace FoodPlannerBlazor.Domain.Entities.Product
{
    public record Product(int Id, string Name, Category.Category Category);
}