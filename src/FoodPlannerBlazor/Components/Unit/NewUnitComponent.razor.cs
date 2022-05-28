using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Domain.Entities.Unit.Outgoing;
using FoodPlannerBlazor.ViewModels;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Unit
{
    public partial class NewUnitComponent : BaseComponent<NewUnitComponentViewModel>
    {
        private CreateUnit _createUnitModel = new();

        private bool showDetailsInformation = false;

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddUnitAsync(_createUnitModel);
            showDetailsInformation = true;
        }
    }
}