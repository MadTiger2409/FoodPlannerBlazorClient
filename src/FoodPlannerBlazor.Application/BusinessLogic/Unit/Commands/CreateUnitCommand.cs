using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands
{
    public record CreateUnitCommand(Domain.Entities.Unit.Outgoing.CreateUnit Unit) : IRequest<ApiResponse<Domain.Entities.Unit.Unit>>;
}