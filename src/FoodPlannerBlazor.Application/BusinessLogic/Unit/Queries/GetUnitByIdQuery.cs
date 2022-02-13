using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Queries
{
    public record GetUnitByIdQuery(int Id) : IRequest<ApiResponse<Domain.Entities.Unit.Unit>>;
}