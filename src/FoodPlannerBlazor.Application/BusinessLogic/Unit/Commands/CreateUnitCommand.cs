using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands
{
    public record CreateUnitCommand(string Name) : IRequest<ApiResponse<Domain.Entities.Unit.Unit>>;
}