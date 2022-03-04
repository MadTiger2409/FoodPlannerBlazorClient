using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Unit
{
    public partial class NewUnitComponent : BaseComponent<NewUnitComponentViewModel>
    {
        private CreateUnitFormModel formModel = new();

        private bool showDetailsInformation = false;

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddUnitAsync(formModel);
            showDetailsInformation = true;
        }
    }
}