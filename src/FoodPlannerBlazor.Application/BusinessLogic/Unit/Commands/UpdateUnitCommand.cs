using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands
{
    public record UpdateUnitCommand(int Id, Domain.Entities.Unit.Outgoing.UpdateUnit Unit) : IRequest<ApiResponse<Domain.Entities.Unit.Unit>>;
}