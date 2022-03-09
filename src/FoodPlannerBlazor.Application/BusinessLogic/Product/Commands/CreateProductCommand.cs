using FoodPlannerBlazor.Infrastructure.Common;
using MediatR;

namespace FoodPlannerBlazor.Application.BusinessLogic.Product.Commands
{
    public record CreateProductCommand(string Name, int CategoryId) : IRequest<ApiResponse<Domain.Entities.Product.Product>>;
}