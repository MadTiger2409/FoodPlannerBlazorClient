namespace FoodPlannerBlazor.Domain.Entities.Product.Incoming
{
    public record Product(int Id, string Name, Category.Incoming.Category Category);
}