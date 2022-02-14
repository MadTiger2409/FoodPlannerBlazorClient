using FoodPlannerBlazor.Domain.Entities.Common;

namespace FoodPlannerBlazor.Domain.Entities.Product
{
    public class Product : NamedEntity
    {
        public Category.Category Category { get; set; }
    }
}