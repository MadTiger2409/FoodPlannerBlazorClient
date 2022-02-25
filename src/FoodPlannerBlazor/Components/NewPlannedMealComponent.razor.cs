using FoodPlannerBlazor.Domain.Entities.Meal;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components
{
    public partial class NewPlannedMealComponent : ComponentBase
    {
        [Inject]
        public NewPlannedMealComponentViewModel ViewModel { get; set; }

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

        public void Dispose() => ViewModel.PropertyChanged -= OnPropertyChangedHandler;

        protected override async Task OnInitializedAsync()
        {
            ViewModel.PropertyChanged += async (sender, e) =>
            {
                await InvokeAsync(() =>
                {
                    StateHasChanged();
                });
            };
            await base.OnInitializedAsync();

            await ViewModel.InitializeMealsListAsync();
        }

        private async void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }
    }
}