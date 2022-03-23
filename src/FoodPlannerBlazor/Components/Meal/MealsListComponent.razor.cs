using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Meal
{
    public partial class MealsListComponent : BaseComponent<MealsListComponentViewModel>
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string Name { get; set; }

        private GetMealsFormModel formModel = new();

        private async Task OnValidSubmitAsync()
        {
            Name = formModel.Name;

            await ViewModel.GetMealsFromApiAsync(formModel.Name);
        }

        protected override async Task OnParametersSetAsync()
        {
            var queryString = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query;
            var parsedQuery = QueryHelpers.ParseQuery(queryString);

            if (parsedQuery.TryGetValue("name", out var name))
            {
                Name = Convert.ToString(name);
            }

            formModel.Name = Name;

            await ViewModel.GetMealsFromApiAsync(Name);
        }
    }
}