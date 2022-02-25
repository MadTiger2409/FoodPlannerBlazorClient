using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Application.BusinessLogic.Meals.Queries
{
    public record GetMealsQuery(string Name = null) : IRequest<ApiResponse<List<Domain.Entities.Meal.Meal>>>;
}