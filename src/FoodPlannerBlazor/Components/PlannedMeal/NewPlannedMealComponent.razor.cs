using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal.Outgoing;
using FoodPlannerBlazor.ViewModels.PlannedMeal;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.PlannedMeal
{
    public partial class NewPlannedMealComponent : TypeaheadBaseComponent<NewPlannedMealComponentViewModel>
    {
        private readonly CreatePlannedMeal _createPlannedMealModel = new();

        private bool showDetailsInformation = false;

        private async Task<IEnumerable<Domain.Entities.Meal.Meal>> SearchMealsAsync(string searchedText)
            => await Task.FromResult(ViewModel.Meals.Where(x => x.Name.ToLower().Contains(searchedText.ToLower())).ToList());

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddPlannedMealAsync(_createPlannedMealModel);
            showDetailsInformation = true;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await ViewModel.InitializeMealsListAsync();
        }
    }
}