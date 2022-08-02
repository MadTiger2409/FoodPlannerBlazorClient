using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels.Category;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Category
{
    public partial class CategoriesListComponent : BaseComponent<CategoriesListComponentViewModel>
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string Name { get; set; }

        private GetCategoriesFormModel formModel = new();

        private async Task OnValidSubmitAsync()
        {
            Name = formModel.Name;

            await ViewModel.GetCategoriesFromApiAsync(formModel.Name);
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

            await ViewModel.GetCategoriesFromApiAsync(Name);
        }
    }
}