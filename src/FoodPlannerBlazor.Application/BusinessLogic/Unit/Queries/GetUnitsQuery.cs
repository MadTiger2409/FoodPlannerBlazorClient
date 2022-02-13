using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Application.BusinessLogic.Unit.Queries
{
    public record GetUnitsQuery() : IRequest<ApiResponse<List<Domain.Entities.Unit.Unit>>>;
}