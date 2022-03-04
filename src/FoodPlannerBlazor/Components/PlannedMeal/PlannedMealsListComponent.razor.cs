using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.PlannedMeal
{
    public partial class PlannedMealsListComponent : BaseComponent<PlannedMealsListComponentViewModel>
    {
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public DateTime From { get; set; } = DateTime.Now.Date;

        [Parameter]
        public DateTime To { get; set; } = DateTime.Now.Date;

        [Parameter]
        public bool IsStatic { get; set; } = false;

        private GetPlannedMealsFormModel formModel = new();

        private async Task OnValidSubmitAsync()
        {
            From = formModel.From;
            To = formModel.To;

            await ViewModel.GetPlannedMealsFromApiAsync(formModel.From, formModel.To);
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
    }
}