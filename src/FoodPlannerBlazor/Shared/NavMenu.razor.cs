using Microsoft.AspNetCore.Components;

namespace FoodPlannerBlazor.Shared
{
    public partial class NavMenu : ComponentBase
    {
        private bool collapseNavMenu = true;
        private bool plannedMealsSubMenuVisible = false;
        private bool categoriesSubMenuVisible = false;
        private bool unitsSubMenuVisible = false;

        private string NavMenuCssClass => collapseNavMenu ? "collapse" : null;

        private void ToggleNavMenu() => collapseNavMenu = !collapseNavMenu;

        private void ToggleSubMenu(ref bool subMenuFlag) => subMenuFlag = !subMenuFlag;
    }
}