using FoodPlannerBlazor.Application.BusinessLogic.Meal.Queries;
using FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Commands;
using FoodPlannerBlazor.Domain.Entities.Meal;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
{
    public class NewPlannedMealComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<PlannedMeal> _response = new();
        private List<Meal> _meals = new();

        public ApiResponse<PlannedMeal> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public List<Meal> Meals
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