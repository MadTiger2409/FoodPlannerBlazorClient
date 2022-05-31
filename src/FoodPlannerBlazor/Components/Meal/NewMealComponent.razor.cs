using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Domain.Entities.Ingredient.Outgoing;
using FoodPlannerBlazor.Domain.Entities.Meal.Outgoing;
using FoodPlannerBlazor.ViewModels;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Meal
{
    public partial class NewMealComponent : BaseComponent<NewMealComponentViewModel>
    {
        private readonly CreateMeal _createMealModel = new();

        private CreateIngredient NewIngredientModel { get; set; } = new();

        private bool showDetailsInformation = false;

        private void AddIngredientToIngredientsList(CreateIngredient ingredient)
        {
            _createMealModel.Ingredients.Add(ingredient);
            NewIngredientModel = new();
        }

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddMealAsync(_createMealModel);
            showDetailsInformation = true;
        }
    }
}
