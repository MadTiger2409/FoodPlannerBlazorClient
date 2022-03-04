using FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands;
using FoodPlannerBlazor.EditFormModels;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels
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

        public async Task AddUnitAsync(CreateUnitFormModel formModel) => Response = await _mediator.Send(new CreateUnitCommand(formModel.Name));
    }
}