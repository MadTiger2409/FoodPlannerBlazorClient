using FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands;
using FoodPlannerBlazor.Domain.Entities.Unit.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels.Unit
{
    public class NewUnitComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<Domain.Entities.Unit.Unit> _response = new();

        public ApiResponse<Domain.Entities.Unit.Unit> Response
        {
            get => _response;
            set => SetValue(ref _response, value);
        }

        public NewUnitComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task AddUnitAsync(CreateUnit formModel) => Response = await _mediator.Send(new CreateUnitCommand(formModel));
    }
}