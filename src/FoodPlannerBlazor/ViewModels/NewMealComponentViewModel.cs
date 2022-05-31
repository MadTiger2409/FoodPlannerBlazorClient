using FoodPlannerBlazor.Application.BusinessLogic.Meal.Commands;
using FoodPlannerBlazor.Domain.Entities.Meal;
using FoodPlannerBlazor.Domain.Entities.Meal.Outgoing;
using FoodPlannerBlazor.Domain.Entities.Product;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
{
    public class NewMealComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<Meal> _response = new();
        private ApiResponse<List<Product>> _products = new();
        private ApiResponse<List<Domain.Entities.Unit.Unit>> _units = new();

        public ApiResponse<Meal> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }
        public ApiResponse<List<Product>> Products
        {
            get => _products;
            set => SetValue(ref _products, value);
        }

        public ApiResponse<List<Domain.Entities.Unit.Unit>> Units
        {
            get => _units;
            set => SetValue(ref _units, value);
        }

        public NewMealComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task AddMealAsync(CreateMeal createMealModel) => Response = await _mediator.Send(new CreateMealCommand(createMealModel));
    }
}