using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System;

namespace FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Commands
{
    public record CreatePlannedMealCommand(int OrdinalNumber, DateTime ScheduledFor, int MealId) : IRequest<ApiResponse<Domain.Entities.PlannedMeal.PlannedMeal>>;
}