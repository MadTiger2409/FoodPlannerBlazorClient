using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Commands
{
    public record CreateCategoryCommand(Domain.Entities.Category.Outgoing.CreateCategory Category) : IRequest<ApiResponse<Domain.Entities.Category.Category>>;
}