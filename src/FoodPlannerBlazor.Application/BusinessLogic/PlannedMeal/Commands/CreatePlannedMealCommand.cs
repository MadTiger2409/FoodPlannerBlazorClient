using FoodPlannerBlazor.Domain.Entities.PlannedMeal.Outgoing;
using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Commands
{
    public record CreatePlannedMealCommand(CreatePlannedMeal CreatePlannedMealModel) : IRequest<ApiResponse<Domain.Entities.PlannedMeal.PlannedMeal>>;
}