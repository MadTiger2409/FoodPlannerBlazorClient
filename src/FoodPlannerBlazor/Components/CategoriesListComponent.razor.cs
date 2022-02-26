using FoodPlannerBlazor.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FoodPlannerBlazor.Components
{
    public partial class CategoriesListComponent : ComponentBase
    {
        [Inject]
        public CategoriesListComponentViewModel ViewModel { get; set; }
    }
}