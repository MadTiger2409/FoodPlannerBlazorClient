using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Application.BusinessLogic.Meal.Queries
{
    public record GetMealsQuery(string Name = null) : IRequest<ApiResponse<List<Domain.Entities.Meal.Meal>>>;
}