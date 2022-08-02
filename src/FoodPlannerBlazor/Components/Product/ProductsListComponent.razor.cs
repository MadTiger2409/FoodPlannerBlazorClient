using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels.Product;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Product
{
    public partial class ProductsListComponent : BaseComponent<ProductsListComponentViewModel>
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private string Name { get; set; }

        private GetProductsFormModel formModel = new();

        private async Task OnValidSubmitAsync()
        {
            Name = formModel.Name;

            await ViewModel.GetProductsFromApiAsync(formModel.Name);
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

            await ViewModel.GetProductsFromApiAsync(Name);
        }
    }
}