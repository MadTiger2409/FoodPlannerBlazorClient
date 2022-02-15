using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Category.Queries
{
    public record GetCategoryByIdQuery(int Id) : IRequest<ApiResponse<Domain.Entities.Category.Category>>;
}