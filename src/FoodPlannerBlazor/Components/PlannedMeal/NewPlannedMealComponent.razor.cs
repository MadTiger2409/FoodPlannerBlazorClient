﻿using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.PlannedMeal
{
    public partial class NewPlannedMealComponent : BaseComponent<NewPlannedMealComponentViewModel>
    {
        private CreatePlannedMealFormModel formModel = new();

        private bool showDetailsInformation = false;

        private int? ConvertMeal(Domain.Entities.Meal.Meal meal) => meal?.Id;

        private Domain.Entities.Meal.Meal LoadSelectedMeal(int? id) => ViewModel.Meals.FirstOrDefault(x => x.Id == id);

        private async Task<IEnumerable<Domain.Entities.Meal.Meal>> SearchMealsAsync(string searchedText)
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