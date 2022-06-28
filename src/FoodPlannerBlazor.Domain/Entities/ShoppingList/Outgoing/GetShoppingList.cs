using System;

namespace FoodPlannerBlazor.Domain.Entities.ShoppingList.Outgoing
{
    public class GetShoppingList
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public float PeopleCount { get; set; }
    }
}
