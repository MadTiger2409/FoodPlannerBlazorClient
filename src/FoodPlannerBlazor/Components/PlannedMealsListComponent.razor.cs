using FoodPlannerBlazor.ViewModels;
using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components
{
    public partial class PlannedMealsListComponent : ComponentBase
    {
        [Inject]
        public PlannedMealsListComponentViewModel ViewModel { get; set; }

        [Parameter]
        public DateTime From { get; set; } = DateTime.UtcNow.Date;

        [Parameter]
        public DateTime To { get; set; } = DateTime.UtcNow.Date;

        protected override async Task OnInitializedAsync()
        {
            await ViewModel.GetPlannedMealsFromApiAsync(From, To);
        }
    }
}