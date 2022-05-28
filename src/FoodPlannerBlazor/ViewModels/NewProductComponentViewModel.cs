using FoodPlannerBlazor.Application.BusinessLogic.Category.Queries;
using FoodPlannerBlazor.Application.BusinessLogic.Product.Commands;
using FoodPlannerBlazor.Domain.Entities.Category;
using FoodPlannerBlazor.Domain.Entities.Product;
using FoodPlannerBlazor.Domain.Entities.Product.Outgoing;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
{
    public class NewProductComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<Product> _response = new();
        private List<Category> _categories = new();

        public ApiResponse<Product> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public List<Category> Categories
        {
            get => _categories;
            set => SetValue(ref _categories, value);
        }

        public NewProductComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task InitializeCategoriesListAsync()
        {
            var apiResponseWithMeals = await _mediator.Send(new GetCategoriesQuery());

            if (apiResponseWithMeals.Success)
                Categories = apiResponseWithMeals.Value;
        }

        public async Task AddProductAsync(CreateProduct formModel)
            => Response = await _mediator.Send(new CreateProductCommand(formModel));
    }
}