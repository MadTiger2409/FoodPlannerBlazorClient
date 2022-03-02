using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Domain.Entities.Meal;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components
{
    public partial class NewPlannedMealComponent : BaseComponent<NewPlannedMealComponentViewModel>
    {
        private CreatePlannedMealFormModel formModel = new();

        private bool showDetailsInformation = false;

        private int? ConvertMeal(Meal meal) => meal?.Id;

        private Meal LoadSelectedMeal(int? id) => ViewModel.Meals.FirstOrDefault(x => x.Id == id);

        private async Task<IEnumerable<Meal>> SearchMealsAsync(string searchedText)
            => await Task.FromResult(ViewModel.Meals.Where(x => x.Name.ToLower().Contains(searchedText.ToLower())).ToList());

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddPlannedMealAsync(formModel);
            showDetailsInformation = true;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await ViewModel.InitializeMealsListAsync();
        }
    }
}