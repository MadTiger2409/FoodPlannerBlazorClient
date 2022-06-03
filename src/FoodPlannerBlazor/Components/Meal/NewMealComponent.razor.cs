using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Domain.Entities.Ingredient.Outgoing;
using FoodPlannerBlazor.Domain.Entities.Meal.Outgoing;
using FoodPlannerBlazor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Meal
{
    public partial class NewMealComponent : TypeaheadBaseComponent<NewMealComponentViewModel>
    {
        private readonly CreateMeal _createMealModel = new();

        private CreateIngredient _newIngredientModel = new();

        private bool showDetailsInformation = false;

        private async Task<IEnumerable<Domain.Entities.Product.Product>> SearchProductsAsync(string searchedText)
            => await Task.FromResult(ViewModel.Products.Where(x => x.Name.ToLower().Contains(searchedText.ToLower())).ToList());

        private async Task<IEnumerable<Domain.Entities.Unit.Unit>> SearchUnitsAsync(string searchedText)
            => await Task.FromResult(ViewModel.Units.Where(x => x.Name.ToLower().Contains(searchedText.ToLower())).ToList());

        private async Task AddIngredientToIngredientsListAsync()
        {
            _createMealModel.Ingredients.Add(_newIngredientModel);
            await Task.FromResult(_newIngredientModel = new());
        }

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddMealAsync(_createMealModel);
            showDetailsInformation = true;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();
            await ViewModel.InitializeDataListsAsync();
        }
    }
}
