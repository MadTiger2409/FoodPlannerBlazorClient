using FoodPlannerBlazor.Domain.Entities.ShoppingList.Outgoing;
using FoodPlannerBlazor.Enums;
using System;

namespace FoodPlannerBlazor.EditFormModels
{
    public class GetShoppingListFormModel
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public float PeopleCount { get; set; }
        public ShoppingListTypeEnum Type { get; set; }

        public static implicit operator GetShoppingList(GetShoppingListFormModel formModel)
        {
            return new()
            {
                From = formModel.From,
                To = formModel.To,
                PeopleCount = formModel.PeopleCount
            };
        }
    }
}
