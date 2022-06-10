using System.Collections.Generic;
using FoodPlannerBlazor.Domain.Entities.Common;
using Microsoft.AspNetCore.Components;

namespace FoodPlannerBlazor.Components.Utilities
{
    public partial class EntitiesNamesListComponent<T> : ComponentBase where T : NamedEntity
    {
        [Parameter]
        public List<T> Entities { get; set; }
    }
}