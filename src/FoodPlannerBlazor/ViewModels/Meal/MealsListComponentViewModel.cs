using FoodPlannerBlazor.Application.BusinessLogic.Meal.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels.Meal
{
    public class MealsListComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<List<Domain.Entities.Meal.Meal>> _response = new();

        public ApiResponse<List<Domain.Entities.Meal.Meal>> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public MealsListComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task GetMealsFromApiAsync(string name) => Response = await _mediator.Send(new GetMealsQuery(name));
    }
}