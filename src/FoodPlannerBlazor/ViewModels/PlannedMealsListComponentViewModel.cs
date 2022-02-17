using FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Queries;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using MvvmBlazor.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
{
    public class PlannedMealsListComponentViewModel : ViewModelBase
    {
        private readonly ISender _mediator;
        private ApiResponse<List<PlannedMeal>> _response = new();

        public ApiResponse<List<PlannedMeal>> Response
        {
            get => _response;
            set => Set(ref _response, value, nameof(Response));
        }

        public PlannedMealsListComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task GetPlannedMealsFromApiAsync(DateTime from, DateTime to) => Response = await _mediator.Send(new GetPlannedMealsQuery(from, to));
    }
}