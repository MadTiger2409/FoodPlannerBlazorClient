using Microsoft.AspNetCore.Components;

namespace FoodPlannerBlazor.Shared
{
    public partial class NavMenu : ComponentBase
    {
        private bool plannedMealsSubMenuVisible = false;
        private bool categoriesSubMenuVisible = false;
        private bool unitsSubMenuVisible = false;
        private bool productsSubMenuVisible = false;
        private bool mealsSubMenuVisible = false;

        private void ToggleSubMenu(ref bool subMenuFlag) => subMenuFlag = !subMenuFlag;
    }
}