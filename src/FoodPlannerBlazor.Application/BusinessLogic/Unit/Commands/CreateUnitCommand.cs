using FoodPlannerBlazor.Domain.Entities.Unit.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands
{
    public record CreateUnitCommand(CreateUnit CreateUnitModel) : IRequest<ApiResponse<Domain.Entities.Unit.Unit>>;
}