using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Commands
{
    public record DeleteUnitCommand(int Id) : IRequest<ApiResponse<string>>;
}
