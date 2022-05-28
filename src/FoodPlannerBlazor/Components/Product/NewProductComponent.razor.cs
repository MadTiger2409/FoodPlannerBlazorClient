using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.Domain.Entities.Product.Outgoing;
using FoodPlannerBlazor.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Product
{
    public partial class NewProductComponent : BaseComponent<NewProductComponentViewModel>
    {
        private readonly CreateProduct _createProductModel = new();

        private bool showDetailsInformation = false;

        private static int? ConvertCategory(Domain.Entities.Category.Category category) => category?.Id;

        private Domain.Entities.Category.Category LoadSelectedCategory(int? id) => ViewModel.Categories.FirstOrDefault(x => x.Id == id);

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