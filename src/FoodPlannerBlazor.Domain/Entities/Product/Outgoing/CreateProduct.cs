using FoodPlannerBlazor.Domain.Entities.Common;

namespace FoodPlannerBlazor.Domain.Entities.Product.Outgoing
{
    public class CreateProduct : NamedOnlyEntity
    {
        public int? CategoryId { get; set; }
    }
}