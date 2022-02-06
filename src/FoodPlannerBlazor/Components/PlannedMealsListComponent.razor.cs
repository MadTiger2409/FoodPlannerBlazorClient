using Microsoft.AspNetCore.Components;
using System;

namespace FoodPlannerBlazor.Components
{
    public partial class PlannedMealsListComponent : ComponentBase
    {
        [Parameter]
        public DateTime From { get; set; } = DateTime.UtcNow.Date;

        [Parameter]
        public DateTime To { get; set; } = DateTime.UtcNow.Date;
    }
}