using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Components
{
    public partial class PlannedMealsListComponent : ComponentBase
    {
        [Parameter]
        public DateTime From { get; set; } = DateTime.UtcNow.Date;

        [Parameter]
        public DateTime To { get; set; } = DateTime.UtcNow.Date;

        public List<int> Ints { get; set; } = new() { 1, 2, 3 };
    }
}