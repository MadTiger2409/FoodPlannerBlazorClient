using FoodPlannerBlazor.Application.BusinessLogic.Unit.Queries;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
{
    public class UnitsListComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<List<Domain.Entities.Unit.Unit>> _response = new();

        public ApiResponse<List<Domain.Entities.Unit.Unit>> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public UnitsListComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task GetUnitsFromApiAsync() => Response = await _mediator.Send(new GetUnitsQuery());
    }
}