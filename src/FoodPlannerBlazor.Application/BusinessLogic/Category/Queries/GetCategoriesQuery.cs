using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Queries
{
    public record GetCategoriesQuery(string Name = null) : IRequest<ApiResponse<List<Domain.Entities.Category.Category>>>;
}