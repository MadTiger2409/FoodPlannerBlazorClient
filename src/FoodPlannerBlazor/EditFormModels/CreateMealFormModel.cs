using System.Collections.Generic;

namespace FoodPlannerBlazor.EditFormModels
{
    public class CreateMealFormModel
    {
        public string Name { get; set; }
        public List<CreateIngredientFormModel> Ingredients { get; set; } = new();
    }
}