﻿using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.ViewModels.Unit;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Unit
{
    public partial class UnitsListComponent : BaseComponent<UnitsListComponentViewModel>
    {
        protected override async Task OnInitializedAsync() => await ViewModel.GetUnitsFromApiAsync();
    }
}