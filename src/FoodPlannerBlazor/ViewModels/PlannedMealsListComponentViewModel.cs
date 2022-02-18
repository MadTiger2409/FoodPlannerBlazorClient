using FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Queries;
using FoodPlannerBlazor.Domain.Entities.PlannedMeal;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
{
    public class PlannedMealsListComponentViewModel : INotifyPropertyChanged
    {
        private readonly ISender _mediator;
        private ApiResponse<List<PlannedMeal>> _response = new();

        public event PropertyChangedEventHandler PropertyChanged;

        public ApiResponse<List<PlannedMeal>> Response
        {
            get => _response;
            set
            {
                if (value == _response)
                    return;

                _response = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Response)));
            }
        }

        public PlannedMealsListComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task GetPlannedMealsFromApiAsync(DateTime from, DateTime to) => Response = await _mediator.Send(new GetPlannedMealsQuery(from, to));
    }
}