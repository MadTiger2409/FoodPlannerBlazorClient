using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;
using System.Collections.Generic;

namespace FoodPlannerBlazor.Application.BusinessLogic.Product.Queries
{
    public record GetProductsQuery(string Name = null) : IRequest<ApiResponse<List<Domain.Entities.Product.Product>>>;
}