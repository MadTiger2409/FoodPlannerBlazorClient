using FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands;
using FoodPlannerBlazor.Application.BusinessLogic.Unit.Queries;
using FoodPlannerBlazor.Domain.Entities.Unit.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using FoodPlannerBlazor.ViewModels.Common;
using MediatR;
using System.Threading.Tasks;

namespace FoodPlannerBlazor.ViewModels.Unit
{
    public class ReadOrUpdateUnitComponentViewModel : BaseViewModel
    {
        private readonly ISender _mediator;
        private ApiResponse<Domain.Entities.Unit.Unit> _getUnitResponse = new();
        private ApiResponse<Domain.Entities.Unit.Unit> _updateUnitResponse = new();
        private ApiResponse<string> _deleteUnitResponse = new();

        public ApiResponse<Domain.Entities.Unit.Unit> GetUnitResponse
        {
            get => _getUnitResponse;
            set => SetValue(ref _getUnitResponse, value);
        }

        public ApiResponse<Domain.Entities.Unit.Unit> UpdateUnitResponse
        {
            get => _updateUnitResponse;
            set => SetValue(ref _updateUnitResponse, value);
        }

        public ApiResponse<string> DeleteUnitResponse
        {
            get => _deleteUnitResponse;
            set => SetValue(ref _deleteUnitResponse, value);
        }

        public ReadOrUpdateUnitComponentViewModel(ISender mediator) => _mediator = mediator;

        public async Task GetUnitFromApiAsync(int id) => GetUnitResponse = await _mediator.Send(new GetUnitByIdQuery(id));
        public async Task UpdateUnitAsync(int id, UpdateUnit formModel)
        {
            UpdateUnitResponse = await _mediator.Send(new UpdateUnitCommand(id, formModel));

            if (UpdateUnitResponse.Error == null && UpdateUnitResponse.Success == true)
                GetUnitResponse = UpdateUnitResponse;
        }

        public async Task DeleteUnitAsync(int id) => DeleteUnitResponse = await _mediator.Send(new DeleteUnitCommand(id));
    }
}
