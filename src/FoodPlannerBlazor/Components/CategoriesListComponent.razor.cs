using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components
{
    public partial class CategoriesListComponent : ComponentBase
    {
        [Inject]
        public CategoriesListComponentViewModel ViewModel { get; set; }

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
        }

        private async void OnPropertyChangedHandler(object sender, PropertyChangedEventArgs e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        public void Dispose() => ViewModel.PropertyChanged -= OnPropertyChangedHandler;
    }
}