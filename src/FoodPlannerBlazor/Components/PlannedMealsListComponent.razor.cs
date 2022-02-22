using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components
{
    public partial class PlannedMealsListComponent : ComponentBase, IDisposable
    {
        [Inject]
        public PlannedMealsListComponentViewModel ViewModel { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public DateTime From { get; set; } = DateTime.Now.Date;

        [Parameter]
        public DateTime To { get; set; } = DateTime.Now.Date;

        [Parameter]
        public bool IsStatic { get; set; } = false;

        private GetPlannedMealsFormModel formModel = new();

        private async Task HandleOnSybmitAsync()
        {
            From = formModel.From;
            To = formModel.To;

            await ViewModel.GetPlannedMealsFromApiAsync(formModel.From, formModel.To);
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

        protected override async Task OnParametersSetAsync()
        {
            var queryString = NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query;
            var parsedQuery = QueryHelpers.ParseQuery(queryString);

            if (parsedQuery.TryGetValue("from", out var from))
            {
                From = Convert.ToDateTime(from);
            }

            if (parsedQuery.TryGetValue("to", out var to))
            {
                To = Convert.ToDateTime(to);
            }

            formModel.From = From;
            formModel.To = To;

            await ViewModel.GetPlannedMealsFromApiAsync(From, To);
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