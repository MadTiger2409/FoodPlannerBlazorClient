using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Meal.Commands
{
    public record CreateMealCommand() : IRequest<ApiResponse<Domain.Entities.Meal.Meal>>;
}
