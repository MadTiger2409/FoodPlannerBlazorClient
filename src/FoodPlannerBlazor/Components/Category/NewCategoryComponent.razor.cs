using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Domain.Entities.Category.Outgoing;
using FoodPlannerBlazor.ViewModels;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Category
{
    public partial class NewCategoryComponent : BaseComponent<NewCategoryComponentViewModel>
    {
        private readonly CreateCategory _createCategoryModel = new();

        private bool showDetailsInformation = false;

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddCategoryAsync(_createCategoryModel);
            showDetailsInformation = true;
        }
    }
}