using FoodPlannerBlazor.Domain.Entities.Meal.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Meal.Commands
{
    public record CreateMealCommand(CreateMeal CreateMealModel) : IRequest<ApiResponse<Domain.Entities.Meal.Meal>>;
}
