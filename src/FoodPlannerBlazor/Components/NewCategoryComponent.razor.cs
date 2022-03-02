using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components
{
    public partial class NewCategoryComponent : BaseComponent<NewCategoryComponentViewModel>
    {
        private CreateCategoryFormModel formModel = new();

        private bool showDetailsInformation = false;

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddCategoryAsync(formModel);
            showDetailsInformation = true;
        }
    }
}