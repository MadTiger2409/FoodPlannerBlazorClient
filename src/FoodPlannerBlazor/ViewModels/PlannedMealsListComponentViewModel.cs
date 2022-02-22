using FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Queries;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
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

        public async Task GetPlannedMealsFromApiAsync(DateTime from, DateTime to) => Response = await _mediator.Send(new GetPlannedMealsQuery(from, to));
    }
}