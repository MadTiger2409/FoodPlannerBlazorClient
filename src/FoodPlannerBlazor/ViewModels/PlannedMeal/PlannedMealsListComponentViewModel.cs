using FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Queries;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels.PlannedMeal
{
    public class PlannedMealsListComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<List<PlannedMealsWithGrouping>> _response = new();

        public ApiResponse<List<PlannedMealsWithGrouping>> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public PlannedMealsListComponentViewModel(ISender mediator) => _mediator = mediator;

        public Task GetPlannedMealsFromApiAsync(DateTime from, DateTime to) => GetPlannedMealsFromApiAsync(from, to, _mediator);
        public async Task GetPlannedMealsFromApiAsync(DateTime from, DateTime to, ISender _mediator)
        {
            var plannedMeals = await _mediator.Send(new GetPlannedMealsQuery(from, to));

            if (plannedMeals.Success && plannedMeals.Value.Count > 0)
                plannedMeals.Value.ForEach(x => x.PlannedMeals = x.PlannedMeals.OrderBy(x => x.OrdinalNumber).ToList());

            Response = plannedMeals;
        }
    }
}