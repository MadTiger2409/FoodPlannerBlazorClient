using FoodPlannerBlazor.Application.BusinessLogic.Meal.Queries;
using FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Commands;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels.PlannedMeal
{
    public class NewPlannedMealComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<Domain.Entities.PlannedMeal.PlannedMeal> _response = new();
        private List<Domain.Entities.Meal.Meal> _meals = new();

        public ApiResponse<Domain.Entities.PlannedMeal.PlannedMeal> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public List<Domain.Entities.Meal.Meal> Meals
        {
            get => _meals;
            set => SetValue(ref _meals, value);
        }

        public NewPlannedMealComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task InitializeMealsListAsync()
        {
            var apiResponseWithMeals = await _mediator.Send(new GetMealsQuery());

            if (apiResponseWithMeals.Success)
                Meals = apiResponseWithMeals.Value;
        }

        public async Task AddPlannedMealAsync(CreatePlannedMeal formModel)
            => Response = await _mediator.Send(new CreatePlannedMealCommand(formModel));
    }
}