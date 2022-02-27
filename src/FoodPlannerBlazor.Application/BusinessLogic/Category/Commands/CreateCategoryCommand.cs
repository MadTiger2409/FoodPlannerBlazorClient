using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Commands
{
    public record CreateCategoryCommand(string Name = "") : IRequest<ApiResponse<Domain.Entities.Category.Category>>;
}