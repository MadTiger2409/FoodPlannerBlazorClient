using FoodPlannerBlazor.Components.Common;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.Components.Product
{
    public partial class NewProductComponent : BaseComponent<NewProductComponentViewModel>
    {
        private CreateProductFormModel formModel = new();

        private bool showDetailsInformation = false;

        private int? ConvertCategory(Domain.Entities.Category.Category category) => category?.Id;

        private Domain.Entities.Category.Category LoadSelectedCategory(int? id) => ViewModel.Categories.FirstOrDefault(x => x.Id == id);

        private async Task<IEnumerable<Domain.Entities.Category.Category>> SearchCategoriesAsync(string searchedText)
            => await Task.FromResult(ViewModel.Categories.Where(x => x.Name.ToLower().Contains(searchedText.ToLower())).ToList());

        private async Task OnValidSubmitAsync()
        {
            await ViewModel.AddProductAsync(formModel);
            showDetailsInformation = true;
        }

        protected override async Task OnInitializedAsync()
        {
            await base.OnInitializedAsync();

            await ViewModel.InitializeCategoriesListAsync();
        }
    }
}