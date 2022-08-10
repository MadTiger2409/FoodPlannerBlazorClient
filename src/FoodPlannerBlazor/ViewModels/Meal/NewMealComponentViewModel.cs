using FoodPlannerBlazor.Application.BusinessLogic.Meal.Commands;
using FoodPlannerBlazor.Application.BusinessLogic.Product.Queries;
using FoodPlannerBlazor.Application.BusinessLogic.Unit.Queries;
using FoodPlannerBlazor.Domain.Entities.Meal.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels.Meal
{
    public class NewMealComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<Domain.Entities.Meal.Meal> _response = new();
        private List<Domain.Entities.Product.Product> _products = new();
        private List<Domain.Entities.Unit.Unit> _units = new();

        public ApiResponse<Domain.Entities.Meal.Meal> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }
        public List<Domain.Entities.Product.Product> Products
        {
            get => _products;
            set => SetValue(ref _products, value);
        }

        public List<Domain.Entities.Unit.Unit> Units
        {
            get => _units;
            set => SetValue(ref _units, value);
        }

        public NewMealComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task InitializeDataListsAsync()
        {
            var apiResponseWithProducts = await _mediator.Send(new GetProductsQuery());
            var apiResponseWithUnits = await _mediator.Send(new GetUnitsQuery());

            if (apiResponseWithProducts.Success)
                Products = apiResponseWithProducts.Value;

            if (apiResponseWithUnits.Success)
                Units = apiResponseWithUnits.Value;
        }

        public async Task AddMealAsync(CreateMeal createMealModel) => Response = await _mediator.Send(new CreateMealCommand(createMealModel));
    }
}