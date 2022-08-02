using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Domain.Entities.Product.Outgoing;
using FoodPlannerBlazor.ViewModels.Product;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Product
{
    public partial class NewProductComponent : TypeaheadBaseComponent<NewProductComponentViewModel>
    {
        private readonly CreateProduct _createProductModel = new();

        private bool showDetailsInformation = false;

        private async Task<IEnumerable<Domain.Entities.Category.Category>> SearchCategoriesAsync(string searchedText)
            => await Task.FromResult(ViewModel.Categories.Where(x => x.Name.ToLower().Contains(searchedText.ToLower())).ToList());

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddProductAsync(_createProductModel);
            showDetailsInformation = true;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await ViewModel.InitializeCategoriesListAsync();
        }
    }
}