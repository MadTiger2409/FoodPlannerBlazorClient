using FoodPlannerBlazor.Domain.Entities.Category.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Commands
{
    public record CreateCategoryCommand(CreateCategory CreateCategoryModel) : IRequest<ApiResponse<Domain.Entities.Category.Category>>;
}