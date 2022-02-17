using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Commands
{
    public record UpdateCategoryCommand(int Id, Domain.Entities.Category.Outgoing.UpdateCategory Category) : IRequest<ApiResponse<Domain.Entities.Category.Category>>;
}