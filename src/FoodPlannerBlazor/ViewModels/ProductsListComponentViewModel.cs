using FoodPlannerBlazor.Application.BusinessLogic.Product.Queries;
using FoodPlannerBlazor.Domain.Entities.Product;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
{
    public class ProductsListComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<List<Product>> _response = new();

        public ApiResponse<List<Product>> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public ProductsListComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task GetProductsFromApiAsync(string name) => Response = await _mediator.Send(new GetProductsQuery(name));
    }
}