using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Application.BusinessLogic.PlannedMeal.Queries
{
    public record GetPlannedMealsQuery(DateTime From, DateTime To) : IRequest<ApiResponse<List<Domain.Entities.PlannedMeal.PlannedMeal>>>;
}